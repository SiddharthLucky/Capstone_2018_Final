using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast_test : MonoBehaviour {

    public GameObject Dolphin;
    private RaycastHit vision;

    //Defining ray cast direction.
    public float raylength;
    public float raylength_negDirection;

    //Vector initializations.
    Vector3 ray_Direction_Front;
    Vector3 ray_Direction_Back;
    Vector3 ray_Direction_Left;
    Vector3 ray_Direction_Right;
    Vector3 ray_Direction_Up;
    Vector3 ray_Direction_Down;

    //Not used yet
    private Rigidbody grabbedObject;

	// Use this for initialization
	void Start ()
    {
        raylength = 25.0f;
        raylength_negDirection = -25.0f;
        Dolphin = GameObject.Find("Dolphin");
        ray_Direction_Front = Dolphin.transform.forward * raylength;
        ray_Direction_Back = Dolphin.transform.forward * raylength_negDirection;
        ray_Direction_Left = Dolphin.transform.right * raylength_negDirection;
        ray_Direction_Right = Dolphin.transform.right * raylength;
        ray_Direction_Up = Dolphin.transform.up * raylength;
        ray_Direction_Down = Dolphin.transform.up * raylength_negDirection;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //This is to see where the ray is going
        Debug.DrawRay(Dolphin.transform.position, ray_Direction_Front, Color.red, 0.5f);
        Debug.DrawRay(Dolphin.transform.position, ray_Direction_Right, Color.red, 0.5f);
        Debug.DrawRay(Dolphin.transform.position, ray_Direction_Left, Color.red, 0.5f);
        Debug.DrawRay(Dolphin.transform.position, ray_Direction_Back, Color.red, 0.5f);
        Debug.DrawRay(Dolphin.transform.position, ray_Direction_Up, Color.red, 0.5f);
        Debug.DrawRay(Dolphin.transform.position, ray_Direction_Down, Color.red, 0.5f);

        //The link to be followed is listed here
        //The code above is in complete
        // Link: Studica, how to create a ray cast in unity.
    }
}
