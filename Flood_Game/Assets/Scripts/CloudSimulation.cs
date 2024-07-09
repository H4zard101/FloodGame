/*using UnityEngine;

public class CloudSimulation : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 targetPosition;
    private bool movingTowardsEnd;

    private void Start()
    {
        targetPosition = GameObject.Find("CloudSimulationEnd").transform.position;
        movingTowardsEnd = true;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

        if (movingTowardsEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                movingTowardsEnd = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CloudSimulationEnd")
        {
            Debug.Log("Collision detected!");
            Debug.Log(other.gameObject.name);
            movingTowardsEnd = false;
        }
    }
}*///one insitance 
/*using UnityEngine;
using System.Collections;


public class CloudSimulation : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private void Start()
    {
        startPosition = GameObject.Find("CloudSimulationStart").transform.position;
        endPosition = GameObject.Find("CloudSimulationEnd").transform.position;

        // Set the initial position of the cloud to the start position
        transform.position = startPosition;

        // Start the cloud movement coroutine
        StartCoroutine(MoveCloud());
    }

    private IEnumerator MoveCloud()
    {
        while (true)
        {
            // Move the cloud from the start position to the end position
            while (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Reset the cloud's position to the start position
            transform.position = startPosition;

            // Wait for a short delay before starting the movement again
            yield return new WaitForSeconds(1f);
        }
    }
}*///cont loop
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudSimulation : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 10f;
    public Slider speedSlider;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private void Start()
    {
        startPosition = GameObject.Find("CloudSimulationStart").transform.position;
        endPosition = GameObject.Find("CloudSimulationEnd").transform.position;

        // Set the initial position of the cloud to the start position
        transform.position = startPosition;

        // Start the cloud movement coroutine
        StartCoroutine(MoveCloud());
    }

    private IEnumerator MoveCloud()
    {
        float currentSpeed = minSpeed;

        while (true)
        {
            // Move the cloud from the start position to the end position
            while (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, currentSpeed * Time.deltaTime);
                yield return null;
            }

            // Reset the cloud's position to the start position
            transform.position = startPosition;

            // Wait for a short delay before starting the movement again
            yield return new WaitForSeconds(1f);

            // Update the speed of the cloud based on the value of the speed slider
            currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, speedSlider.value);
        }
    }
}*///using slider
/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloudSimulation : MonoBehaviour
{
    public Slider speedSlider;
    public float defaultSpeed = 5f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed;

    private Coroutine movementCoroutine;

    private void Start()
    {
        startPosition = GameObject.Find("CloudSimulationStart").transform.position;
        endPosition = GameObject.Find("CloudSimulationEnd").transform.position;

        // Set the initial position of the cloud to the start position
        transform.position = startPosition;

        // Set the initial speed to the default speed
        speed = defaultSpeed;

        // Start the cloud movement coroutine
        movementCoroutine = StartCoroutine(MoveCloud());
    }

    private void Update()
    {
        // Update the speed based on the value of the speed slider
        speed = defaultSpeed * speedSlider.value;

        // Stop the cloud movement coroutine if the stop button is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopCoroutine(movementCoroutine);
        }
    }

    private IEnumerator MoveCloud()
    {
        while (true)
        {
            // Move the cloud from the start position to the end position
            while (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Reset the cloud's position to the start position
            transform.position = startPosition;

            // Wait for a short delay before starting the movement again
            yield return new WaitForSeconds(1f);
        }
    }
}*///using slider with all 5 speed 
/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloudSimulation : MonoBehaviour
{
    public Slider speedSlider;
    public float defaultSpeed = 5f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed;
    public Button stopButton;

    private Coroutine movementCoroutine;

    private void Start()
    {
        startPosition = GameObject.Find("CloudSimulationStart").transform.position;
        endPosition = GameObject.Find("CloudSimulationEnd").transform.position;

        // Set the initial position of the cloud to the start position
        transform.position = startPosition;

        // Set the initial speed to the default speed
        speed = defaultSpeed;

        // Start the cloud movement coroutine
        movementCoroutine = StartCoroutine(MoveCloud());

        // Set the onclick event of the stop button to stop the cloud movement coroutine
        stopButton.onClick.AddListener(StopCloudMovement);
    }

    private void Update()
    {
        // Update the speed based on the value of the speed slider
        speed = defaultSpeed * speedSlider.value;
    }

    private IEnumerator MoveCloud()
    {
        while (true)
        {
            // Move the cloud from the start position to the end position
            while (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Reset the cloud's position to the start position
            transform.position = startPosition;

            // Wait for a short delay before starting the movement again
            yield return new WaitForSeconds(1f);
        }
    }

    private void StopCloudMovement()
    {
        // Stop the cloud movement coroutine
        StopCoroutine(movementCoroutine);
    }
}*///using the stop button 
/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloudSimulation : MonoBehaviour
{
    public Slider speedSlider;
    public float defaultSpeed = 5f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed;
    public Button stopButton;
    public Button startButton;

    private Coroutine movementCoroutine;

    private void Start()
    {
        startPosition = GameObject.Find("CloudSimulationStart").transform.position;
        endPosition = GameObject.Find("CloudSimulationEnd").transform.position;

        // Set the initial position of the cloud to the start position
        transform.position = startPosition;

        // Set the initial speed to the default speed
        speed = defaultSpeed;

        // Start the cloud movement coroutine
        movementCoroutine = StartCoroutine(MoveCloud());

        // Set the onclick event of the stop button to stop the cloud movement coroutine
        stopButton.onClick.AddListener(StopCloudMovement);

        // Set the onclick event of the start button to start the cloud movement coroutine
        startButton.onClick.AddListener(StartCloudMovement);
    }

    private void Update()
    {
        // Update the speed based on the value of the speed slider
        speed = defaultSpeed * speedSlider.value;
    }

    private IEnumerator MoveCloud()
    {
        while (true)
        {
            // Move the cloud from the start position to the end position
            while (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Reset the cloud's position to the start position
            transform.position = startPosition;

            // Wait for a short delay before starting the movement again
            yield return new WaitForSeconds(1f);
        }
    }

    private void StopCloudMovement()
    {
        // Stop the cloud movement coroutine
        StopCoroutine(movementCoroutine);
    }

    private void StartCloudMovement()
    {
        // Start the cloud movement coroutine
        movementCoroutine = StartCoroutine(MoveCloud());
    }
}*///using start button
/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloudSimulation : MonoBehaviour
{
    public Slider speedSlider;
    public float defaultSpeed = 5f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed;
    public ParticleSystem particleSystemZero;
    public ParticleSystem particleSystemOne;
    public ParticleSystem particleSystemTwo;
    public ParticleSystem particleSystemThree;
    public ParticleSystem particleSystemFour;
    public ParticleSystem particleSystemFive;
    public Button stopButton;
    public Button startButton;

    private Coroutine movementCoroutine;
    private ParticleSystem[] allParticleSystems;

    private void Start()
    {
        startPosition = GameObject.Find("CloudSimulationStart").transform.position;
        endPosition = GameObject.Find("CloudSimulationEnd").transform.position;

        // Set the initial position of the cloud to the start position
        transform.position = startPosition;

        // Set the initial speed to the default speed
        speed = defaultSpeed;

        // Get all particle systems
        allParticleSystems = new ParticleSystem[] { particleSystemZero, particleSystemOne, particleSystemTwo, particleSystemThree, particleSystemFour, particleSystemFive };

        // Start the cloud movement coroutine
        movementCoroutine = StartCoroutine(MoveCloud());

        // Set the onclick event of the stop button to stop the cloud movement coroutine
        stopButton.onClick.AddListener(StopCloudMovement);

        // Set the onclick event of the start button to start the cloud movement coroutine
        startButton.onClick.AddListener(StartCloudMovement);
    }

    private void Update()
    {
        // Update the speed based on the value of the speed slider
        speed = defaultSpeed * speedSlider.value;
    }

    private IEnumerator MoveCloud()
    {
        while (true)
        {
            // Move the cloud from the start position to the end position
            while (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Reset the cloud's position to the start position
            transform.position = startPosition;

            // Stop all particle systems
            foreach (ParticleSystem ps in allParticleSystems)
            {
                ps.Stop();
            }

            // Wait for a short delay before starting the movement again
            yield return new WaitForSeconds(1f);

            // Start all particle systems
            foreach (ParticleSystem ps in allParticleSystems)
            {
                ps.Play();
            }
        }
    }

    private void StopCloudMovement()
    {
        // Stop the cloud movement coroutine
        StopCoroutine(movementCoroutine);

        // Stop all particle systems
        foreach (ParticleSystem ps in allParticleSystems)
        {
            ParticleSystem.EmissionModule em = ps.emission;
            em.enabled = false;
        }
    }

    private void StartCloudMovement()
    {
        // Start the cloud movement coroutine
        movementCoroutine = StartCoroutine(MoveCloud());

        // Start all particle systems
        foreach (ParticleSystem ps in allParticleSystems)
        {
            ParticleSystem.EmissionModule em = ps.emission;
            em.enabled = true;
        }
    }
}*/// particle system stops and starts when stopped and starts 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloudSimulation : MonoBehaviour
{
    public Slider speedSlider;
    public float defaultSpeed = 5f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed;
    public ParticleSystem particleSystemZero;
    public ParticleSystem particleSystemOne;
    public ParticleSystem particleSystemTwo;
    public ParticleSystem particleSystemThree;
    public ParticleSystem particleSystemFour;
    public ParticleSystem particleSystemFive;
    public Button stopButton;
    public Button startButton;
    public World world;


    private Coroutine movementCoroutine;
    private ParticleSystem[] allParticleSystems;

    private void Start()
    {
        startPosition = GameObject.Find("CloudSimulationStart").transform.position;
        endPosition = GameObject.Find("CloudSimulationEnd").transform.position;

        // Find the World object in the scene and assign it to the world variable
        world = GameObject.FindObjectOfType<World>();

        // Set the phase of the World script to Build
        world.phase = World.Phase.Build;

        // Set the initial position of the cloud to the start position
        transform.position = startPosition;

        // Set the initial speed to the default speed
        speed = defaultSpeed;

        // Get all particle systems
        allParticleSystems = new ParticleSystem[] { particleSystemZero, particleSystemOne, particleSystemTwo, particleSystemThree, particleSystemFour, particleSystemFive };

        // Start the cloud movement coroutine
        movementCoroutine = StartCoroutine(MoveCloud());

        // Set the onclick event of the stop button to stop the cloud movement coroutine
        stopButton.onClick.AddListener(StopCloudMovement);

        // Set the onclick event of the start button to start the cloud movement coroutine
        startButton.onClick.AddListener(StartCloudMovement);
    }

    private void Update()
    {
        // Update the speed based on the value of the speed slider
        speed = defaultSpeed * speedSlider.value;
    }

    private IEnumerator MoveCloud()
    {
        while (true)
        {
            // Move the cloud from the start position to the end position
            while (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Reset the cloud's position to the start position
            transform.position = startPosition;

            // Stop all particle systems
            foreach (ParticleSystem ps in allParticleSystems)
            {
                ps.Stop();
            }

            // Wait for a short delay before starting the movement again
            yield return new WaitForSeconds(1f);

            // Start all particle systems
            foreach (ParticleSystem ps in allParticleSystems)
            {
                ps.Play();
            }
        }
    }

    private void StopCloudMovement()
    {
        // Stop the cloud movement coroutine
        StopCoroutine(movementCoroutine);

        // Stop all particle systems
        foreach (ParticleSystem ps in allParticleSystems)
        {
            ParticleSystem.EmissionModule em = ps.emission;
            em.enabled = false;
        }
    }

    private void StartCloudMovement()
    {
        // Start the cloud movement coroutine
        movementCoroutine = StartCoroutine(MoveCloud());

        // Start all particle systems
        foreach (ParticleSystem ps in allParticleSystems)
        {
            ParticleSystem.EmissionModule em = ps.emission;
            em.enabled = true;
        }
    }
}
