using UnityEngine;
using UnityEngine.Tilemaps;
using Unity.Mathematics;

public class BombSpawner : MonoBehaviour
{
    public int IsAlive;
    public Tilemap tilemap;
    public int PosX;
    public int PosY;
    public GameObject Player1;
    public GameObject bombP;

    // Update is called once per frame
    void Update()
    {
        Player1 AliveVerifier = Player1.GetComponent<Player1>();
        IsAlive = AliveVerifier.Alive;
        if (Input.GetKeyDown("space"))
        {
            if (IsAlive == 1)
            {
                PosX = (int)(Mathf.Floor(Player1.transform.position.x));
                PosY = (int)(Mathf.Floor(Player1.transform.position.y));
                Vector3Int CellPos = new Vector3Int(PosX, PosY, 0);
                Vector3 CenterPos = tilemap.GetCellCenterWorld(CellPos);
                Debug.Log(CellPos);
                Instantiate(bombP, CenterPos, Quaternion.identity);
            }
        }
        
    }
}
