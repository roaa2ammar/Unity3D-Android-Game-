using System;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class binary : MonoBehaviour
{
    public Text number; // number showing on screen
    public int randomNum; // The randomly generated number
    public string converted; // will hold the converted denary as a string
    public int score; // keep track of the score 
    public Text Scoretext; // views the score using text gameobject 

   
   
    public void RandomButton(){ // to add it to the OnClick() for the button
        RandomNumber(255);
    }

    public void CheckBinary(string userAns)
    {
        Debug.Log(userAns); // for debugging 
        converted = Convert.ToInt32(userAns, 2).ToString(); // converts binary string to denary string 
        Debug.Log(converted); // for testing the binary convert feature

        Debug.Log(randomNum); // for debugging

        if ((int.Parse(converted)) == randomNum){ // compare answer
            Debug.Log("Correct"); // for debugging 
            score = score + 10;
            Scoretext.text = "Score: " + score.ToString();
        }
        else{
            Debug.Log("Incorrect"); // for debugging 
        }


    }

    public void RandomNumber( int maxInt){ // takes in max number                                          
        randomNum = Random.Range(1, maxInt + 1); // random number
        number.text = randomNum.ToString(); // display number on text gameobject   
    }


}
