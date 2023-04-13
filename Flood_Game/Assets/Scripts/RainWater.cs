using UnityEngine;
using UnityEngine.Tilemaps;

public class RainWater : MonoBehaviour
{
    public float rainIntensity = 0.1f;
    public Tilemap waterTilemap;

    private void Update()
    {
        Vector3Int tilemapSize = waterTilemap.size;
        for (int x = 0; x < tilemapSize.x; x++)
        {
            for (int y = 0; y < tilemapSize.y; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                TileBase tile = waterTilemap.GetTile(tilePos);
                if (tile != null)
                {
                    float rand = Random.Range(0f, 1f);
                    if (rand < rainIntensity)
                    {
                        waterTilemap.SetTile(tilePos, null);
                        if (y < tilemapSize.y - 1)
                        {
                            waterTilemap.SetTile(new Vector3Int(x, y + 1, 0), tile);
                        }
                    }
                }
            }
        }
    }
}
