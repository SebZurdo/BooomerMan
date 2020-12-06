using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{
    public Tilemap tilemap;

    public GameObject bombP;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 PosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int CellPos = tilemap.WorldToCell(PosInWorld);
            Vector3 CenterPos = tilemap.GetCellCenterWorld(CellPos);

            Instantiate(bombP, CenterPos, Quaternion.identity);
        }
    }
}
