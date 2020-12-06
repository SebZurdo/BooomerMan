using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestroyer : MonoBehaviour
{
    public Tilemap Grid;

    public int n;

    public Tile Wall;

    public Tile Border;

    public Tile Breakable;

    public GameObject BoomAnimation;


    public void Explode(Vector2 PosInWorld)
    {
        Vector3Int ExplosionCenter = Grid.WorldToCell(PosInWorld);
        n = 5;
        RemoveCell(ExplosionCenter);
        /*
        if (RemoveCell(ExplosionCenter + new Vector3Int(1, 0, 0))){
            RemoveCell(ExplosionCenter + new Vector3Int(2, 0, 0));
        }
        if (RemoveCell(ExplosionCenter + new Vector3Int(0, 1, 0))){
            RemoveCell(ExplosionCenter + new Vector3Int(0, 2, 0));
        }
        if (RemoveCell(ExplosionCenter + new Vector3Int(-1, 0, 0))){
            RemoveCell(ExplosionCenter + new Vector3Int(-2, 0, 0));
        }
        if (RemoveCell(ExplosionCenter + new Vector3Int(0, -1, 0))){
            RemoveCell(ExplosionCenter + new Vector3Int(0, -2, 0));
        }*/
        for (int i = 1; i < n; i++)
        {
            if (RemoveCell(ExplosionCenter + new Vector3Int(i, 0, 0))){
                RemoveCell(ExplosionCenter + new Vector3Int(i+1, 0, 0));
                continue;
            }
            break;
        }
        for (int i = 1; i < n; i++)
        {
            if (RemoveCell(ExplosionCenter + new Vector3Int(0, i, 0))){
                RemoveCell(ExplosionCenter + new Vector3Int(0, i+1, 0));
                continue;
            }
            break;
        }
        for (int i = 1; i < n; i++)
        {
            if (RemoveCell(ExplosionCenter + new Vector3Int(-i, 0, 0))){
                RemoveCell(ExplosionCenter + new Vector3Int(-(i+1), 0, 0));
                continue;
            }
            break;
        }
        for (int i = 1; i < n; i++)
        {
            if (RemoveCell(ExplosionCenter + new Vector3Int(0, -i, 0))){
                RemoveCell(ExplosionCenter + new Vector3Int(0, -(i+1), 0));
                continue;
            }
            break;
        }
    }

    bool RemoveCell(Vector3Int cell)
    {
        Tile TileKind = Grid.GetTile<Tile>(cell);

        if(TileKind == Wall)
        {
            return false;
        }
        if(TileKind == Border)
        {
            return false;
        }

        if(TileKind == Breakable)
        {
            Grid.SetTile(cell, null);
        }

        Vector3 Pos = Grid.GetCellCenterWorld(cell);
        Instantiate(BoomAnimation, Pos, Quaternion.identity);

        return true;
    }
}
