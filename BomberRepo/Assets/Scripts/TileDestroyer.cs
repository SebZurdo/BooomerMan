﻿using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestroyer : MonoBehaviour
{
    public GameObject Player1;

    public GameObject Player2;

    public Tilemap Grid;

    public int n;

    public int random;

    public Tile Wall;

    public Tile Border;

    public Tile Breakable;

    public GameObject BoomAnimation;
    
    public GameObject FirePowerUp;

    public GameObject SkatePowerUp;


    public void Explode(Vector2 PosInWorld)
    {
        Vector3Int ExplosionCenter = Grid.WorldToCell(PosInWorld);
        Player1 BombPower = Player1.GetComponent<Player1>();
        n = BombPower.BombPower;
        if (RemoveCell(ExplosionCenter))
        {
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(i, 0, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(i + 1, 0, 0));
                    continue;
                }
                break;
            }
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(0, i, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(0, i + 1, 0));
                    continue;
                }
                break;
            }
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(-i, 0, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(-(i + 1), 0, 0));
                    continue;
                }
                break;
            }
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(0, -i, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(0, -(i + 1), 0));
                    continue;
                }
                break;
            }
        }
    }

    public void Explode_2(Vector2 PosInWorld)
    {
        Vector3Int ExplosionCenter = Grid.WorldToCell(PosInWorld);
        Player2 BombPower = Player2.GetComponent<Player2>();
        n = BombPower.BombPower;
        if (RemoveCell(ExplosionCenter))
        {
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(i, 0, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(i + 1, 0, 0));
                    continue;
                }
                break;
            }
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(0, i, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(0, i + 1, 0));
                    continue;
                }
                break;
            }
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(-i, 0, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(-(i + 1), 0, 0));
                    continue;
                }
                break;
            }
            for (int i = 1; i < n; i++)
            {
                if (RemoveCell(ExplosionCenter + new Vector3Int(0, -i, 0)))
                {
                    RemoveCell(ExplosionCenter + new Vector3Int(0, -(i + 1), 0));
                    continue;
                }
                break;
            }
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
            Vector3 PowerPos = Grid.GetCellCenterWorld(cell);
            random = UnityEngine.Random.Range(0,8);
            switch (random)
            {
                case 0:
                    Instantiate(FirePowerUp, PowerPos, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(SkatePowerUp, PowerPos, Quaternion.identity);
                    break;
            }
        }

        Vector3 Pos = Grid.GetCellCenterWorld(cell);
        Instantiate(BoomAnimation, Pos, Quaternion.identity);

        return true;
    }


}
