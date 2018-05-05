using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable] // It shows the values in the isnpector
public class fish_AIObjects
{
    public string fishGroupName { get { return m_fishAIGroupname;}}
    public GameObject objectPrefab { get { return m_prefab; } }
    public int maxAI { get { return m_maxAI; } }
    public int spawnRate { get { return m_spawnRate; } }
    public int spawnAmount { get { return m_maxSpawnAmount; } }
    public bool randomizeStats { get { return m_randomizeStats; } }
    public bool fish_enableSpawner { get { return m_enableSpawner; } }

    [Header("Fish AI Group Stats")]
    [SerializeField]
    private string m_fishAIGroupname;
    [SerializeField]
    private GameObject m_prefab;
    [SerializeField]
    [Range(0f, 50f)]
    private int m_maxAI;
    [SerializeField]
    [Range(0f, 30f)]
    private  int m_spawnRate;
    [SerializeField]
    [Range(0f, 20f)]
    private int m_maxSpawnAmount;
    [SerializeField]
    private bool m_randomizeStats;
    [SerializeField]
    private bool m_enableSpawner;

    // Constructor for accessing AI values above
    public fish_AIObjects(string fish_Name, GameObject fish_Prefab, int fish_MaxAI, int fish_SpawnRate, int fish_SpawnAmount, bool fish_RandomizeStats)
    {
        this.m_fishAIGroupname = fish_Name;
        this.m_prefab = fish_Prefab;
        this.m_maxAI = fish_MaxAI;
        this.m_spawnRate = fish_SpawnRate;
        this.m_maxSpawnAmount = fish_SpawnAmount;
        this.m_randomizeStats = fish_RandomizeStats;
    }

    public void fish_Setvalues(int set_fishMaxAI, int set_fishSpawnRate, int set_fishSpawnAmount)
    {
        this.m_maxAI = set_fishMaxAI;
        this.m_spawnRate = set_fishSpawnRate;
        this.m_maxSpawnAmount = set_fishSpawnAmount;
    }

}

public class Fish_AISpawner : MonoBehaviour {

    // We use a list for getting the no if waypoints assuming we dont know how many waypoints are there.
    public List<Transform> fish_Waypoints = new List<Transform>();

    public float fish_SpawnTimer { get { return m_fishspawnTimer; } }
    public Vector3 fish_SpawnArea { get { return m_fishspawnArea; } }
    [Header("Global Stats")]
    [Range(0f, 600f)]
    [SerializeField]
    public float m_fishspawnTimer;
    [SerializeField]
    private Color m_fishSpawnColor = new Color(1.000f, 0.000f, 0.000f, 0.300f); // Sets the color for the gizmo.
    [SerializeField]
    private Vector3 m_fishspawnArea = new Vector3(148f, 45f, 148f);  

    // Create array from the new class
    [Header("Fish AI Group Settings")]
    public fish_AIObjects[] fish_AIObject = new fish_AIObjects[5]; // This will be used to generate 5 instances of the above class.

	// Use this for initialization
	void Start ()
    {
        GetwayPoints();
        RandomizeGroups();
        CreateAIGroups();
        InvokeRepeating("FishSpawnNPC", 0.5f, fish_SpawnTimer);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Function will be used to spawn the fishes and contains AI to make them Move
    void FishSpawnNPC()
    {
        int count = 0;
        // loop through all the AI groups
        for (int i = 0; i< fish_AIObject.Count(); i++)
        {
            // Check to make sure the fish spawner is enabled
            if(fish_AIObject[i].fish_enableSpawner && fish_AIObject[i].objectPrefab != null)
            {
                // Make sure that the AI group diesnt have Max NPC's
                // Need a better way to fing the GameObject for the AI
                GameObject tempGroup = GameObject.Find(fish_AIObject[i].fishGroupName);
                if (tempGroup.GetComponentInChildren<Transform>().childCount < fish_AIObject[i].maxAI)
                {
                    
                    // Spawn random number of NPC;s from 0 to max spawn amount
                    for (int y = 0; y < Random.Range(0, fish_AIObject[i].spawnAmount); y++)
                    {
                        Quaternion randomRoatation = Quaternion.Euler(Random.Range(-20, 20), Random.Range(0, 360), 0);
                        // Create spawned game object
                        GameObject tempSpawn;
                        tempSpawn = Instantiate(fish_AIObject[i].objectPrefab, RandomPosition(), randomRoatation);
                        // Put spawned NPC as a child group
                        tempSpawn.transform.parent = tempGroup.transform;
                        //Add the AI Move script and class
                        if(count == 0)
                        {
                            tempSpawn.tag = "Fishies";
                            count++;
                        }
                        
                        tempSpawn.AddComponent<FishAIMove>();
                    }
                }
            }
        }
    }

    // Random position generates objects randomly in our spawn area.
    public Vector3 RandomPosition()
    {
        Vector3 randomPostion = new Vector3(
            Random.Range(-fish_SpawnArea.x, fish_SpawnArea.x),
            Random.Range(-fish_SpawnArea.y, fish_SpawnArea.y),
            Random.Range(-fish_SpawnArea.z, fish_SpawnArea.z)
            );
        randomPostion = transform.TransformPoint(randomPostion * .5f);
        // Returns the random position for the fishes to spawn
        return randomPostion;
    }

    // Picking a random waypoint
    // Helps fishes to pick a random waypoint
    public Vector3 RandomWaypoint()
    {
        int randomWP = Random.Range(0, (fish_Waypoints.Count - 1));
        Vector3 randomWaypoint = fish_Waypoints[randomWP].transform.position;
        return randomWaypoint;
    }

    void RandomizeGroups()
    {
        // Method for putting random values in the AI group
        for( int i = 0; i < fish_AIObject.Count(); i++)
        {
            if(fish_AIObject[i].randomizeStats)
            {
                //fish_AIObject[i] = new fish_AIObjects(fish_AIObject[i].fishGroupName, fish_AIObject[i].objectPrefab, Random.Range(0, 30), Random.Range(0, 20), Random.Range(0, 10), fish_AIObject[i].randomizeStats);
                // The randomize values intialized above will not be destroyed.
                fish_AIObject[i].fish_Setvalues(Random.Range(0, 30), Random.Range(0, 20), Random.Range(0, 10));
            }
        }
    }

    // Method for creating empty world object groups.
    void CreateAIGroups()
    {
        for(int i = 0; i < fish_AIObject.Count(); i++)
        {
            // Empty game objects to keep the AI in.
            GameObject m_fishAIGroupSpawn;

            // Create a new game object
            m_fishAIGroupSpawn = new GameObject(fish_AIObject[i].fishGroupName);
            m_fishAIGroupSpawn.transform.parent = this.gameObject.transform;
        }
    }

    void GetwayPoints()
    {
        // List to look through all the nested children.
        Transform[] fish_waypointList = transform.GetComponentsInChildren<Transform>();
        for(int i = 0; i < fish_waypointList.Length; i++ )
        {
            if (fish_waypointList[i].tag == "fish_waypoint")
            {
                // Adding values of waypoints to the list
                fish_Waypoints.Add(fish_waypointList[i]);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = m_fishSpawnColor;
        Gizmos.DrawCube(transform.position, fish_SpawnArea);
    }
}
