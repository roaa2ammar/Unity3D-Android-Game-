using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player; // a reference to the player

    void LateUpdate () {

        Vector3 newPosition = player.position; // new position of the minimap camera 
        newPosition.y = transform.position.y; // y stays the same
        transform.position = newPosition;   
    }     
}

