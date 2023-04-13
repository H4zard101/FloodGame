/*using UnityEngine;

public class CloudsController : MonoBehaviour
{
    public GameObject cloudPrefab;  // This is the prefab of the cloud that you want to spawn.
    public int numberOfClouds = 10;  // This is the number of clouds that you want to spawn.
    public float minX = -10f;  // This is the minimum x position where a cloud can be spawned.
    public float maxX = 10f;  // This is the maximum x position where a cloud can be spawned.
    public float minY = 2f;  // This is the minimum y position where a cloud can be spawned.
    public float maxY = 6f;  // This is the maximum y position where a cloud can be spawned.
    public float minZ = -10f;  // This is the minimum z position where a cloud can be spawned.
    public float maxZ = 10f;  // This is the maximum z position where a cloud can be spawned.
    public float minScale = 0.5f;  // This is the minimum scale of the cloud that will be spawned.
    public float maxScale = 1.5f;  // This is the maximum scale of the cloud that will be spawned.

    void Start()
    {
        // Spawn the clouds.
        for (int i = 0; i < numberOfClouds; i++)
        {
            Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            float scale = Random.Range(minScale, maxScale);

            GameObject cloud = Instantiate(cloudPrefab, position, Quaternion.identity, transform);
            cloud.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}*/
using System.Collections;
using UnityEngine;

public class CloudsController : MonoBehaviour
{
    public GameObject cloudPrefab;  // This is the prefab of the cloud that you want to spawn.
    public int numberOfClouds = 10;  // This is the number of clouds that you want to spawn.
    public float minX = -10f;  // This is the minimum x position where a cloud can be spawned.
    public float maxX = 10f;  // This is the maximum x position where a cloud can be spawned.
    public float minY = 2f;  // This is the minimum y position where a cloud can be spawned.
    public float maxY = 6f;  // This is the maximum y position where a cloud can be spawned.
    public float minZ = -10f;  // This is the minimum z position where a cloud can be spawned.
    public float maxZ = 10f;  // This is the maximum z position where a cloud can be spawned.
    public float minScale = 0.5f;  // This is the minimum scale of the cloud that will be spawned.
    public float maxScale = 1.5f;  // This is the maximum scale of the cloud that will be spawned.
    public float moveDelay = 5f; // This is the amount of time it takes for a cloud to move to a new random position.

    private GameObject[] clouds; // This will hold references to all the spawned clouds.

    void Start()
    {
        // Spawn the clouds.
        clouds = new GameObject[numberOfClouds];
        for (int i = 0; i < numberOfClouds; i++)
        {
            Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            float scale = Random.Range(minScale, maxScale);

            GameObject cloud = Instantiate(cloudPrefab, position, Quaternion.identity, transform);
            cloud.transform.localScale = new Vector3(scale, scale, scale);
            clouds[i] = cloud;
        }

        // Start the coroutine that will move the clouds after a certain amount of time.
        StartCoroutine(MoveClouds());
    }

    IEnumerator MoveClouds()
    {
        while (true)
        {
            // Wait for the specified delay before moving the clouds.
            yield return new WaitForSeconds(moveDelay);

            // Move each cloud to a new random position.
            for (int i = 0; i < numberOfClouds; i++)
            {
                Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
                float scale = Random.Range(minScale, maxScale);

                GameObject cloud = clouds[i];
                cloud.transform.position = position;
                cloud.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }
}