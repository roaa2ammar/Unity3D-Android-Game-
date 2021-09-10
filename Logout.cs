using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class Logout : MonoBehaviour
{
    public void doLogout() {
        
        FirebaseAuth.DefaultInstance.SignOut(); // calls the Firebase Signout function
         if(FirebaseAuth.DefaultInstance.CurrentUser == null){ // To check if it has logged out successfully
             Debug.Log("logged out");
        }
    }

}
