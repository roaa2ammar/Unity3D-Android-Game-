using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // using the Scene manager 

public class gotoLogout : MonoBehaviour
{
    public Animator transition; // using the Animator to get the fading animations 
    public float transitiontime = 1f; // set the tranistion time here so I can change it from Inspector if needed
  
    public void LoadLogout() {

        transition.SetTrigger("Start"); // triggers the animation
        SceneManager.LoadScene(0); // login scene index 
    }
}

