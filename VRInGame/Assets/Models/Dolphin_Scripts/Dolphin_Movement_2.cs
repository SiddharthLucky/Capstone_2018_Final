using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dolphin_Movement_2 : MonoBehaviour {

    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float timeForNewPath;
    bool inCoRoutine; //Called each time a path is not working
    Vector3 target;
    bool validPath;

    // Use this for initialization
    void Start ()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
	}

    //Method to find a new Random position.
    Vector3 getNewRandomPostion()
    {
        int x = Random.Range(-180, 180);
        int z = Random.Range(-180, 180);
        int y = Random.Range(100, 150);
        Vector3 pos = new Vector3(x, y, z);
        return pos;
    }

    //Function to manage operations
    IEnumerator DoSomething()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        //Method to get new Path
        GetNewPath();
        validPath = navMeshAgent.CalculatePath(target, path);
        if (!validPath) Debug.Log("Found an invalid path");

        while(!validPath)
        {
            yield return new WaitForSeconds(0.000001f);
            GetNewPath();
            validPath = navMeshAgent.CalculatePath(target, path); //This breaks the infinate loop.
        }
        inCoRoutine = false;
    }

    void GetNewPath()
    {
        target = getNewRandomPostion();
        navMeshAgent.SetDestination(getNewRandomPostion());
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(!inCoRoutine)
            StartCoroutine(DoSomething());
	}

    //Fixing the next edge finder
}
