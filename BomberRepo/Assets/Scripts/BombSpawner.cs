using UnityEngine;
using UnityEngine.Tilemaps;
using Unity.Mathematics;

public class BombSpawner : MonoBehaviour
{
    public int IsAlive_1;
    public int IsAlive_2;
    public Tilemap tilemap;
    public int PosX;
    public int PosY;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject bombP;

    // Update is called once per frame
    void Update()
    {
        Player1 AliveVerifier_1 = Player1.GetComponent<Player1>();
        Player2 AliveVerifier_2 = Player2.GetComponent<Player2>();
        
        IsAlive_1 = AliveVerifier_1.Alive;
        IsAlive_2 = AliveVerifier_2.Alive;

        if (Input.GetKeyDown("."))
        {
            if (IsAlive_1 == 1)
            {
                PosX = (int)(Mathf.Floor(Player1.transform.position.x));
                PosY = (int)(Mathf.Floor(Player1.transform.position.y));
                Vector3Int CellPos = new Vector3Int(PosX, PosY, 0);
                Vector3 CenterPos = tilemap.GetCellCenterWorld(CellPos);
                Debug.Log(CellPos);
                Instantiate(bombP, CenterPos, Quaternion.identity);
            }
        }

        if (Input.GetKeyDown("v"))
        {
           if (IsAlive_2 == 1)
            {
                PosX = (int)(Mathf.Floor(Player2.transform.position.x));
                PosY = (int)(Mathf.Floor(Player2.transform.position.y));
                Vector3Int CellPos = new Vector3Int(PosX, PosY, 0);
                Vector3 CenterPos = tilemap.GetCellCenterWorld(CellPos);
                Debug.Log(CellPos);
                Instantiate(bombP, CenterPos, Quaternion.identity);
            } 
        }
        
    }
}
