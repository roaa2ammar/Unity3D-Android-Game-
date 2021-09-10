using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class joymove : MonoBehaviour
{
    public FixedJoystick moveJoystick; // using the FixedJoystick script available from the Joystick package
    private Animator Anim;  // To use the animations in the Animator
    
    

    void Start()
    {
        Anim = gameObject.GetComponent<Animator> (); // Setting the variable Anim 
        
        
    }

    // Update is called once per frame
    void Update() // using Update() to have it keep checking at each frame if the joystick has been moved.
    {
        //get the x/y position of the joystick 
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        //Setting the direction of where the joystick has been moved 
    
        Vector3 direction = new Vector3(hoz, 0, ver).normalized; // getting the direction of the joystick movement.
        
        if (hoz != 0) {  // If the joystick is not at 0 (Not moved) then set walking animation to true to start walking.
            Anim.SetBool ("isWalking" , true);
        }
        else {  // otherwise the player would also not be moving.
            Anim.SetBool ("isWalking" , false);
        }
        transform.Translate(direction * 0.1f, Space.World);// This would translate the character with the joystick direction at 0.1 per frame. 
 // I can change the speed if I think it is walking a bit slow.
    }
}


