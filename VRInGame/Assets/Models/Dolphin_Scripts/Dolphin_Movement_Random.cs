using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin_Movement_Random : MonoBehaviour
{
    //Visible in inspector initialization
    public int totalToCatch;

    //Initialized all the variables
    [HideInInspector]
    public float Dolphin_controlSpeed, waterLevel, Dolphin_direction_travelTime, count_TimerDown;
    [HideInInspector]
    public bool isUnderWater;
    [HideInInspector]
    public int checkVal, fishCaught;
    [HideInInspector]
    public string inTerrainBounds;


    // Use this for initialization
    void Start()
    {
        //Change this value in the end, temp initialization.
        totalToCatch = 10;
        Dolphin_controlSpeed = 0.01f;
        waterLevel = 76.6f;
        isUnderWater = transform.position.y < waterLevel;
        fishCaught = 0;
        count_TimerDown = RandomTimePicker();
    }

    // Update is called once per frame
    void Update()
    {
        inTerrainBounds = "YES";
        //Not using the while loop as of now
        //while (fishCaught <= totalToCatch)
        while(fishCaught <= 10)
        {
            count_TimerDown -= Time.deltaTime;
            if(count_TimerDown >= 0)
            { 
                if(inTerrainBounds.Contains("YES"))
                {
                    transform.Translate(Vector3.forward * Dolphin_controlSpeed * Time.deltaTime);
                }
                else
                {
                    float new_Dolphin_Direction_picker = Dolphin_AnglePicker();
                    //Rotate the dolphin after you caheck for bountries
                }
                //itterating the no of fish caught. 
                fishCaught++;
            }
        }

    }

    //This validation can be done by the cube boundry made
    //string Terrain_Validator()
    //{
    //    string boundCheck = "";
    //    var temp_DolphinChecker = GameObject.Find("Dolphin");
    //    var temp_DolphinPosition = Vector3.zero;
    //    if(temp_DolphinChecker)
    //    {
    //        temp_DolphinPosition = temp_DolphinChecker.transform.position;
    //        boundCheck = "YES";
    //    }
    //    return boundCheck;
    //}

    int RandomTimePicker()
    {
        int TempInt = Random.Range(3, 8);
        return TempInt;
    }

    float Dolphin_AnglePicker()
    {
        float angle_Holder = 0.0f;
        return angle_Holder;
    }

}