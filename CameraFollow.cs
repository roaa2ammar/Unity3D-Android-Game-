using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     private Transform target; // this is a reference to what I want the camera to follow which is the character.

     public Vector3 offset; // I want to be able to offset the camera on all 3 axis so I used Vector3

    
     void Awake() // I used Awake() so that it would get called immediately the first time the GameObject (the charcter) is enabled 
     {
        target = GameObject.FindGameObjectWithTag("Player").transform; // it will search for the game object with the tag "Player" 
     }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset; /* Here I am just adding the character position vector to the offset vector to give 
        the new camera position. */
    }
}
