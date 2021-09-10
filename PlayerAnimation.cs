using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator Anim; // to use the animations added in Unity's Animator 


    void Awake() // once the game is started, the animator gets called so it can be used in this class
    {
        Anim = GetComponent<Animator>();
    }

    public void startwalk() // function to set the walking animation to true
    {
        Anim.SetBool ("isWalking" , true);
    }

    public void stopwalk() // function to set walking animation to false
    {
        Anim.SetBool ("isWalking" , false);
    }


    public void startjump() // function to set jumping animation to true 
    {   
        Debug.Log("startjump called"); // I added this to ensure that when I pressed the button the correct function was being executed.
        Anim.SetBool ("isJumping" , true);         
    }

    public void stopjump() // function set jumping animation to false 
    {
        Anim.SetBool ("isJumping" , false);
    }
} 
