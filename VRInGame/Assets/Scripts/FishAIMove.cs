using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAIMove : MonoBehaviour {

    // Declare variables for AI Spawner manager script
    private Fish_AISpawner m_fishAIManager;

    // Declare variables for moving and turning
    private bool m_fishhasTarget = false;
    private bool m_fishIsTurning;

    // Variable for current waypoint
    private Vector3 m_fishWayPoint;
    private Vector3 m_fishlastWayPoint = new Vector3(0f, 0f, 0f); // This is to check if the new waypoint is same as the last one

    // These variables will be used to set the animation speed
    private Animator m_fishAnimator;
    private float m_fishSpeed;

    // Adding and checking with a collider to make the fish behaviour look more realistic
    private Collider m_fishCollider;
    
    // Use this for initialization
	void Start ()
    {
        m_fishAIManager = transform.parent.GetComponentInParent<Fish_AISpawner>();
        m_fishAnimator = GetComponent<Animator>();
        Fish_SetupNPC();
	}

    void Fish_SetupNPC()
    {
        //Randomly sacale each NPC
        float m_fishScale = Random.Range(5f, 9f);
        transform.localScale += new Vector3(m_fishScale * 7f, m_fishScale, m_fishScale);

        // Checking to see if the prefab has a collider
        // Add it even if the child has a collider.

        if(transform.GetComponent<Collider>() != null && transform.GetComponent<Collider>().enabled == true)
        {
            m_fishCollider = transform.GetComponent<Collider>();
        }
        else if(transform.GetComponentInChildren<Collider>() != null && transform.GetComponentInChildren<Collider>().enabled == true)
        {
            m_fishCollider = transform.GetComponentInChildren<Collider>();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(!m_fishhasTarget)
        {
            m_fishhasTarget = Fish_CanFindTarget();
        }
        else
        {
            // Rotate the NPC to face the waypoint - fish
            Fish_RotateNPC(m_fishWayPoint, m_fishSpeed);
            // Move the NPC in a straight line toawards the target waypoint
            transform.position = Vector3.MoveTowards(transform.position, m_fishWayPoint, m_fishSpeed * Time.deltaTime);

            //Check if the fish collided, if yes, look for a new waypoint
            //FishCollidedNPC();
        }

        // If NPC reaches the waypoints reset the targets
        if(transform.position == m_fishWayPoint)
        {
            m_fishhasTarget = false;
        }
	}

    bool Fish_CanFindTarget(float fish_start = 15f, float fish_end = 25f)
    {
        m_fishWayPoint = m_fishAIManager.RandomWaypoint();
        if(m_fishlastWayPoint == m_fishWayPoint)
        {
            // Get a new waypoint
            m_fishWayPoint = m_fishAIManager.RandomWaypoint();
            return false;
        }
        else
        {
            // Function accepted setting the new waypoint as the last waypoint
            m_fishlastWayPoint = m_fishWayPoint;
            // Get random speed for movement and animation
            m_fishSpeed = Random.Range(fish_start, fish_end);
            m_fishAnimator.speed = m_fishSpeed;
            // Set boolen value to true as we found a waypoint
            return true;
        }
    }

    // Function to rotate the fish to a calid direction
    void Fish_RotateNPC(Vector3 fish_waypoint, float fish_currentSpeed)
    {
        //get random speed up for the turn
        float fish_TurnSpeed = fish_currentSpeed * Random.Range(1f, 3f);

        //get a new direction to look at the target
        Vector3 fish_LookAt = fish_waypoint - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(fish_LookAt), fish_TurnSpeed * Time.deltaTime);
    }

    // method to check if the fish collided with another fish or a body
    void FishCollidedNPC()
    {
        RaycastHit fish_hit;
        if(Physics.Raycast(transform.position, transform.forward, out fish_hit, transform.localScale.z))
        {
           if(fish_hit.collider == m_fishCollider | fish_hit.collider.tag == "fish_waypoint")
            {
                return;
            }

            // Randomizing the chance where the fish will change direction agter bumping
            int randomFish_num = Random.Range(1, 100);
            if(randomFish_num < 40)
            {
                m_fishhasTarget = false;
            }

            // Loggin the various colliders hits.
            Debug.Log(fish_hit.collider.transform.parent.name + " "+ fish_hit.collider.transform.parent.position);
        }
    }

    // The Fish initially spawn at a fixed location,
    // Using thsi function will make it truly random.

    Vector3 Fish_getWayPoint(bool fish_isRandom)
    {
        // if fish_isRandom true then get a random position location
        if(fish_isRandom)
        {
            return m_fishAIManager.RandomPosition();
        }

        // This will be used to get a random waypoint
        else
        {
            return m_fishAIManager.RandomWaypoint();
        }
    }
    
}
