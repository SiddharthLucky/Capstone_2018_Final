using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Random : MonoBehaviour
{
    [HideInInspector]
    public float Timer, Pick_Time;
    [HideInInspector]
    public float speed_Picker, Vert_speed, Hori_speed;
    [HideInInspector]
    public int directionVal, Pick_direction;
    [HideInInspector]
    public int angle1, angle2, angle3, angle4, angle5, angle6;

    // Use this for initialization
    void Start()
    {
        Timer = RandomTime();
        Vert_speed = 1.5f;
        Hori_speed = RandomSpeed();
        directionVal = Direction_picker();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime; 
        if(Timer > 0)
        {
            transform.Translate(Vector3.up *Vert_speed * Time.deltaTime, Space.World);
        }

        Start();
    }


    //Function Area
    float RandomTime()
    {
        Pick_Time = Random.Range(3, 7);
        return Pick_Time;
    }
    
    float RandomSpeed()
    {
        speed_Picker = Random.Range(4, 8);
        return speed_Picker;
    }

    int Direction_picker()
    {
        angle1 = Random.Range(0, 9);
        angle2 = Random.Range(9, 18);
        angle3 = Random.Range(18, 27);
        angle4 = Random.Range(27, 36);
        angle5 = Random.Range(36, 45);
        angle6 = Random.Range(45, 72);
        int[] dic_Picker_Arr = {angle1, angle2, angle3, angle4, angle5, angle6};
        Pick_direction = dic_Picker_Arr[Random.Range(0, 5)] * 5;
        return Pick_direction;
    }
}

