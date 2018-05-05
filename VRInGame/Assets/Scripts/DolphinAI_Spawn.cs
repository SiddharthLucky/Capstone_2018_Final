using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DolphinAI_SingleObject
{
    public string DolphinGroupName { get { return m_DolphinAIGroupname; } }
    //public GameObject Dolphin_objectPrefab { get { return m_Dolphinprefab; } }

    [Header("Dolphin AI Stats")]
    [SerializeField]
    private string m_DolphinAIGroupname;

    // Create array from the new class
    

    // Not applicable right now
    //[SerializeField]
    //private GameObject m_Dolphinprefab;

    // Uncomment the below for dolphin group customization


    // Constructor for accessing AI values above
    public DolphinAI_SingleObject(string Dolphin_Name)//, GameObject fish_Prefab)
    {
        this.m_DolphinAIGroupname = Dolphin_Name;
        //this.m_Dolphinprefab = fish_Prefab;
    }

}


// You can use this script if you want to generate multiple dolphins.
public class DolphinAI_Spawn : MonoBehaviour {

    // List that holds all the waypoints for the dolphin to move
    public List<Transform> Dolphin_Waypoints = new List<Transform>();
    // Use this for initialization
    void Start ()
    {
        DolphinGetwayPoints();
        InvokeRepeating("DolphinSpawnNPC", 3.0f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DolphinGetwayPoints()
    {
        // List to look through all the nested children.
        Transform[] dolphin_waypointList = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < dolphin_waypointList.Length; i++)
        {
            // Initially for checking we are using the same waypoints as the fishes
            if (dolphin_waypointList[i].tag == "fish_waypoint")
            {
                // Adding values of waypoints to the list
                Dolphin_Waypoints.Add(dolphin_waypointList[i]);
            }
        }
    }

    void DolphinSpawnNPC()
    {
        // Need a better way to fing the GameObject for the AI
        GameObject DolphinVal = GameObject.Find("Dolphin_Master");
        Quaternion randomRoatation = Quaternion.Euler(Random.Range(-20, 20), Random.Range(0, 360), 0);
        DolphinVal.AddComponent<DolphinAI_Movement>();
    }

    public Vector3 RandomWaypoint()
    {
        int Dolphin_randomWP = Random.Range(0, (Dolphin_Waypoints.Count - 1));
        Vector3 Dolphin_randomWaypoint = Dolphin_Waypoints[Dolphin_randomWP].transform.position;
        return Dolphin_randomWaypoint;
    }
}
