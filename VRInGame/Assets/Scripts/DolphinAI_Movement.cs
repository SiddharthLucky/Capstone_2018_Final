using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System;

public class DolphinAI_Movement : MonoBehaviour
{
    [HideInInspector]
    public GameObject DolphinVal;
    [HideInInspector]
    public GameObject FishVal1;
    [HideInInspector]
    public GameObject FishVal2;
    [HideInInspector]
    public GameObject FishVal3;

    public List<GameObject> Dolphin_Waypoints = new List<GameObject>();
    // Declare variables for moving and turning
    private bool m_DolphinhasTarget = false;
    private bool m_DolphinIsTurning;
    private float m_dolphinSpeed = 10f;
    private float m_dolphinAngSpeed = 13f;

    // Variable for current waypoint
    private Vector3 m_DolphinWayPoint;
    private Vector3 m_DolphinTempWaypoint;
    private Vector3 m_FishTempLocationHolder;
    private Vector3 m_FishLastTempLocationHolder;
    private Vector3 m_DolphintoFishWaypoint;
    private Vector3 m_DolphinlastWayPoint = new Vector3(0f, 0f, 0f); // This is to check if the new waypoint is same as the last one

    private Collider m_DolphinCollider;

    private Rigidbody rb_Dolphin;

    //Decleration for angular motion
    //Variables used here again for clarity
    //private float m_dolphinSpeed = 10f;
    private float m_DolphinTurn = 20f;
    public int fish_caught_count = 0;
    public Text fishCounterText;

    //Variables for establishing socket
    private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private byte[] _recieveBuffer = new byte[8142];
    private bool Dolphin_Rec_Ack;


    void Start ()
    {
        fish_caught_count = 0;
        SetCounter();
        rb_Dolphin = GetComponent<Rigidbody>();
        DolphinVal = GameObject.Find("Dolphin");
        rb_Dolphin.gameObject.GetComponent<Rigidbody>();
        FishVal1 = GameObject.Find("Fish_Chaser1");
        FishVal2 = GameObject.Find("Fish_Chaser2");
        FishVal3 = GameObject.Find("Fish_Chaser3");
        GetwayPoints();
        Dolphin_SetupNPC();
        SetupServer();
        Dolphin_Rec_Ack = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Check if you recieved a trigger
            if (!m_DolphinhasTarget)
            {
                m_DolphinhasTarget = Dolphin_CanFindTarget();
            }

            else
            {
                Dolphin_RotateNPC(m_DolphinWayPoint, m_dolphinSpeed);
                transform.position = Vector3.MoveTowards(transform.position, m_DolphinWayPoint, m_dolphinSpeed * Time.deltaTime);
                DolphinCollidedNPC();
            }

            // if NPC reaches the waypoints reset the targets
            // Temp collision Chekcker

            if (transform.position == m_DolphinWayPoint)
            {
                m_DolphinhasTarget = false;
            }

            m_DolphinTempWaypoint = m_DolphinWayPoint;
            m_FishTempLocationHolder = Pick_RandomFish();
            if(m_FishLastTempLocationHolder == m_FishTempLocationHolder)
            {
                m_FishLastTempLocationHolder = m_FishTempLocationHolder;
                m_FishTempLocationHolder = Pick_RandomFish();
            }
            //m_FishLastTempLocationHolder = m_FishTempLocationHolder;
            
            if (Dolphin_Rec_Ack == true)
            {
                StartCoroutine(ChaseFish(m_DolphinTempWaypoint, m_FishTempLocationHolder));
            }

    }

    IEnumerator ChaseFish(Vector3 tempWaypointHolder, Vector3 tempFishHolder)
    {
        Debug.Log("Entered Coroutine");

        while (Vector3.Distance(tempFishHolder, DolphinVal.transform.position) > 0.001)
        {
            Dolphin_RotateNPC(tempFishHolder, m_dolphinSpeed);
            transform.position = Vector3.MoveTowards(transform.position, tempFishHolder, m_dolphinSpeed * Time.deltaTime);
        }
        fish_caught_count += 1;        
        SetCounter();
        Debug.Log("Finished while loop coroutine");
        Dolphin_Rec_Ack = false;
        yield return null;
        
    }
   

    void OnCollisionEnter(Collision col)
    {        
        if (col.gameObject.name.Contains("Fish_Waypoint_Cube"))
        {
            Debug.Log("Collision occoured");
            m_DolphinhasTarget = false;
        }

    }


    //Make a function to see if you recieved a trigger to start chasing a fish


    //Functions to check for collisions 
    void Dolphin_SetupNPC()
    {
        if(transform.GetComponent<Collider>() != null && transform.GetComponent<Collider>().enabled == true)
        {
            m_DolphinCollider = transform.GetComponent<Collider>();
        }
        if (transform.GetComponentInChildren<Collider>() != null && transform.GetComponentInChildren<Collider>().enabled == true)
        {
            m_DolphinCollider = transform.GetComponentInChildren<Collider>();
        }
    }

    bool Dolphin_CanFindTarget(float dolphin_start = 1f, float dolphin_end = 7f)
    {
        m_DolphinWayPoint = Dolphin_RandomWaypoint();
        if(m_DolphinlastWayPoint == m_DolphinWayPoint)
        {
            m_DolphinWayPoint = Dolphin_RandomWaypoint();
            return false;
        }
        else
        {
            m_DolphinlastWayPoint = m_DolphinWayPoint;
            m_dolphinSpeed = 12f;
            return true;
        }
    }

    void DolphinCollidedNPC()
    {
        RaycastHit DolphinHit;
        Collider Dolphin_ColliderHolder;
        
        Dolphin_ColliderHolder = gameObject.GetComponent<MeshCollider>();
        
        if(Physics.Raycast(transform.position, transform.forward, out DolphinHit, transform.localScale.z))
        {
            if(DolphinHit.collider == m_DolphinCollider | DolphinHit.collider.tag == "fish_waypoint")
            {
                m_DolphinhasTarget = false;
            }
            //Debug.Log(DolphinHit.collider.transform.parent.name + " " + DolphinHit.collider.transform.parent.position);
        }

    }

    // This is called to make the dolphin face the fish when the trigger is fired

    void Dolphin_RotateNPC(Vector3 dolphin_waypoint , float dolphin_currentSpeed)
    {
        float dolphin_TurnSpeed = dolphin_currentSpeed;

        // Get a new Direction to look at the target
        Vector3 dolphin_LookAt = dolphin_waypoint - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dolphin_LookAt), dolphin_TurnSpeed * Time.deltaTime);
    }

    void GetwayPoints()
    {
        // List to look through all the nested children.
        GameObject[] Dolphin_waypointList = (GameObject[])FindObjectsOfType(typeof(GameObject));
        for (int i = 0; i < Dolphin_waypointList.Length; i++)
        {
            if (Dolphin_waypointList[i].name.Contains("fish_waypoint"))
                Dolphin_waypointList[i].tag = tag;
        }
        for (int i = 0; i < Dolphin_waypointList.Length; i++)
        {
            if (Dolphin_waypointList[i].tag == "fish_waypoint")
            {
                // Adding values of waypoints to the list
                Dolphin_Waypoints.Add(Dolphin_waypointList[i]);
            }
        }

    }

    public Vector3 Dolphin_RandomWaypoint()
    {
        int Dolphin_randomWP = UnityEngine.Random.Range(0, (Dolphin_Waypoints.Count - 1));
        Vector3 Dolphin_randomWaypoint = Dolphin_Waypoints[Dolphin_randomWP].transform.position;
        return Dolphin_randomWaypoint;
    }

    public void SetCounter()
    {
        fishCounterText.text = "Fish Caught: " + fish_caught_count;
    }

    public Vector3 Pick_RandomFish()
    {
        Vector3 Fish_Selected1 = FishVal1.transform.position;
        Vector3 Fish_Selected2 = FishVal2.transform.position;
        Vector3 Fish_Selected3 = FishVal3.transform.position;
        int Randomizer = UnityEngine.Random.Range(1,3);
        if(Randomizer == 1)
        {
            m_FishTempLocationHolder = Fish_Selected1;
        }
        else if(Randomizer == 2)
        {
            m_FishTempLocationHolder = Fish_Selected2;
            
        }
        else if(Randomizer == 3)
        {
            m_FishTempLocationHolder = Fish_Selected3;
        }

        return m_FishTempLocationHolder;
        
    }

    public void SetupServer()

    {
        try
        {
            _clientSocket.Connect("10.1.250.238", 3002);
        }
        catch (SocketException ex)
        {
            Debug.Log(ex.Message);
        }
        _clientSocket.BeginReceive(_recieveBuffer, 0, _recieveBuffer.Length, SocketFlags.None, new System.AsyncCallback(ReceiveCallback), null);
        Debug.Log("Soc Setup");
    }

    public void ReceiveCallback(System.IAsyncResult AR)
    {
        string ackContainer = string.Empty;
        //Check how much bytes are recieved and call EndRecieve to finalize handshake
        int recieved = _clientSocket.EndReceive(AR);
        if (recieved <= 0)
            return;
        //Copy the recieved data into new buffer , to avoid null bytes
        byte[] recData = new byte[recieved];
        System.Buffer.BlockCopy(_recieveBuffer, 0, recData, 0, recieved);
        ackContainer = System.Text.Encoding.UTF8.GetString(recData);
        if(ackContainer.Contains("1catch1fish"))
        {
            Dolphin_Rec_Ack = true;
        }
        Debug.Log(ackContainer);
        SendData(System.Text.Encoding.ASCII.GetBytes("Acknowledged"));
        //Start receiving again
        _clientSocket.BeginReceive(_recieveBuffer, 0, _recieveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
    }

    public void SendData(byte[] data)
    {
        SocketAsyncEventArgs socketAsyncData = new SocketAsyncEventArgs();
        socketAsyncData.SetBuffer(data, 0, data.Length);
        _clientSocket.SendAsync(socketAsyncData);
    }
}



