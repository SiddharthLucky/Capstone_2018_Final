using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_ChaserScript : MonoBehaviour
{
    public GameObject Fish_ChaserVal;

    public List<GameObject> Fish_Chaser_Waypoints = new List<GameObject>();

    // Declaring variables for movement and turning
    private bool m_FishChaserhasTarget = false;
    private bool m_FishChaserIsTurning;
    private float m_fishChaserSpeed = 10f;

    // Variable for current waypoint
    private Vector3 m_FishChaserWayPoint;
    private Vector3 m_FishChasertoFishWaypoint;
    private Vector3 m_FishChaserlastWayPoint = new Vector3(0f, 0f, 0f); // This is to check if the new waypoint is same as the last one

    private Collider m_FishChaserCollider;

    // Use this for initialization
    void Start()
    {
        Fish_ChaserVal = GameObject.Find("Fish_Chaser1");
        FishChaser_GetwayPoints();
        FishChaser_SetupNPC();

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_FishChaserhasTarget)
        {
            m_FishChaserhasTarget = FishChaser_CanFindTarget();
        }

        else
        {
            FishChaser_RotateNPC(m_FishChaserlastWayPoint, m_fishChaserSpeed);
            transform.position = Vector3.MoveTowards(transform.position, m_FishChaserWayPoint, m_fishChaserSpeed * Time.deltaTime);
            FishChaser_CollidedNPC();
        }

        // If NPC reaches the waypoints reset the changes
        // Temp Collision Checker
        if (transform.position == m_FishChaserWayPoint)
        {
            m_FishChaserhasTarget = false;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Fish_Waypoint_Cube"))
        {
            Debug.Log("Collision occoured");
            m_FishChaserhasTarget = false;
        }
    }

    // Make a function to see if you recieved a trigger to start chasing the fish
    // Function to check for collisions

    void FishChaser_SetupNPC()
    {
        if (transform.GetComponent<Collider>() != null && transform.GetComponent<Collider>().enabled == true)
        {
            m_FishChaserCollider = transform.GetComponent<Collider>();
        }
        if (transform.GetComponentInChildren<Collider>() != null && transform.GetComponentInChildren<Collider>().enabled == true)
        {
            m_FishChaserCollider = transform.GetComponentInChildren<Collider>();
        }

    }

    bool FishChaser_CanFindTarget(float fishChaser_start = 1f, float fishChaser_end = 7f)
    {
        m_FishChaserWayPoint = FishChaser_RandomWaypoint();
        if (m_FishChaserlastWayPoint == m_FishChaserWayPoint)
        {
            m_FishChaserWayPoint = FishChaser_RandomWaypoint();
            return false;
        }
        else
        {
            m_FishChaserlastWayPoint = m_FishChaserWayPoint;
            m_fishChaserSpeed = 12f;
            return true;
        }
    }

    void FishChaser_CollidedNPC()
    {
        RaycastHit FishChaserHit;
        Collider FishChaser_ColliderHolder;

        FishChaser_ColliderHolder = gameObject.GetComponent<SphereCollider>();

        if (Physics.Raycast(transform.position, transform.forward, out FishChaserHit, transform.localScale.z))
        {
            if (FishChaserHit.collider == m_FishChaserCollider | FishChaserHit.collider.tag == "fish_waypoint")
            {
                m_FishChaserhasTarget = false;
            }
            //Debug.Log(FishChaserHit.collider.transform.parent.name + " " + FishChaserHit.collider.transform.parent.position);
        }

    }

    void FishChaser_RotateNPC(Vector3 fishchaser_waypoint, float fishchaser_currentSpeed)
    {
        float fishchaser_TurnSpeed = fishchaser_currentSpeed;

        // Get a new Direction to look at the target
        Vector3 fishchaser_LookAt = fishchaser_waypoint - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(fishchaser_LookAt), fishchaser_TurnSpeed * Time.deltaTime);
    }

    void FishChaser_GetwayPoints()
    {
        // List to look through all the nested children.
        GameObject[] FishChaser_waypointList = (GameObject[])FindObjectsOfType(typeof(GameObject));
        for (int i = 0; i < FishChaser_waypointList.Length; i++)
        {
            if (FishChaser_waypointList[i].name.Contains("fish_waypoint"))
                FishChaser_waypointList[i].tag = tag;
        }
        for (int i = 0; i < FishChaser_waypointList.Length; i++)
        {
            if (FishChaser_waypointList[i].tag == "fish_waypoint")
            {
                // Adding values of waypoints to the list
                Fish_Chaser_Waypoints.Add(FishChaser_waypointList[i]);
            }
        }

    }

    public Vector3 FishChaser_RandomWaypoint()
    {
        int fishchaser_randomWP = Random.Range(0, (Fish_Chaser_Waypoints.Count - 1));
        Vector3 FishChaser_randomWaypoint = Fish_Chaser_Waypoints[fishchaser_randomWP].transform.position;
        return FishChaser_randomWaypoint;
    }

}
