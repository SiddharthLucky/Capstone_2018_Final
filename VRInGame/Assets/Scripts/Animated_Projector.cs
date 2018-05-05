using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animated_Projector : MonoBehaviour
{

    public float fps = 30.0f;
    public Texture2D[] frames;

    private int frameIndex;
    private Projector projector;


    // Use this for initialization
    void Start()
    {
        projector = GetComponent<Projector>();
        NextFrame();
        InvokeRepeating("NextFrame", 1 / fps, 1 / fps);
    }
    //Refers to the next frame to be projected
    void NextFrame()
    {
        projector.material.SetTexture("_ShadowTex", frames[frameIndex]);
        frameIndex = (frameIndex + 1) % frames.Length;
    }

}
