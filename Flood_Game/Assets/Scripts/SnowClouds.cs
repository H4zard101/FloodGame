using UnityEngine;

public class SnowClouds : MonoBehaviour
{
    public GameObject snowCloudPrefab;
    public int numberOfSnowClouds = 10;
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = 2f;
    public float maxY = 6f;
    public float minZ = -10f;
    public float maxZ = 10f;
    public float minScale = 0.5f;
    public float maxScale = 1.5f;

    void Start()
    {
        for (int i = 0; i < numberOfSnowClouds; i++)
        {
            Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            float scale = Random.Range(minScale, maxScale);

            GameObject snowCloud = Instantiate(snowCloudPrefab, position, Quaternion.identity, transform);
            snowCloud.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
