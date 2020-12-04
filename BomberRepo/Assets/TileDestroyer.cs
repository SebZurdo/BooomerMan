using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestroyer : MonoBehaviour
{
    public Tilemap Grid;

    public Tile Wall;

    public Tile Breakable;

    public GameObject BoomAnimation;

    public void Explode(Vector2 PosInWorld)
    {
        Vector3Int ExplosionCenter = Grid.WorldToCell(PosInWorld);

        RemoveCell(ExplosionCenter);
    }

    public void RemoveCell(Vector3Int cell)
    {
        Tile TileKind = Grid.GetTile<Tile>(cell);

        if(TileKind == Wall)
        {
            return;
        }

        if(TileKind == Breakable)
        {
            Grid.SetTile(cell, null);
        }

        Vector3 Pos = Grid.GetCellCenterWorld(cell);
        Instantiate(BoomAnimation, Pos, Quaternion.identity);
    }
}
