using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public World world;
    public GameTimeManager gameTime;

    [SerializeField]private List<GameObject> cloudList = new List<GameObject>();

    [SerializeField] private Vector3 startingPosition;

    public void Start()
    {
        world = FindObjectOfType<World>();
        gameTime = FindObjectOfType<GameTimeManager>();

        startingPosition = this.gameObject.transform.position;

        // Loop through all the child objects of the cloud manager gameobject
        foreach (Transform cloudObject in transform)
        {
            // Add objects to a list
            cloudList.Add(cloudObject.transform.gameObject);

            // Loop through the list and set them to not be active
            for (int i = 0; i < cloudList.Count; i++)
            {
                cloudList[i].gameObject.SetActive(false);
            }
        }
    }

    public void Update()
    {
        if(world.phase == World.Phase.Simulation)
        {
            // Set the clouds to be visible
            for (int i = 0; i < cloudList.Count; i++)
            {
                // Set active
                cloudList[i].gameObject.SetActive(true);

                // Play the particles
                cloudList[i].GetComponentInChildren<ParticleSystem>().Play();

                // Move the Clouds

                this.gameObject.transform.Translate(0, 0, (float)(- 0.1 * gameTime.gameTimeSlider.value * Time.deltaTime));
            }

        }

        else if(world.phase == World.Phase.Pause)
        {
            // Stop the movement
            for (int i = 0; i < cloudList.Count; i++)
            {

                // Pause the particles
                cloudList[i].GetComponentInChildren<ParticleSystem>().Pause();
            }
        }

        else if(world.phase == World.Phase.Build)
        {
            // De spawn the clouds
            // Stop the movement
            for (int i = 0; i < cloudList.Count; i++)
            {            
                // Pause the particles
                cloudList[i].GetComponentInChildren<ParticleSystem>().Stop();

                // Re set their posistions back the start pos
                this.gameObject.transform.position = startingPosition;

                // Set active
                cloudList[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CloudEndPoint")
        {
            Debug.Log("Hello");
            world.phase = World.Phase.Build;
        }
    }
}
