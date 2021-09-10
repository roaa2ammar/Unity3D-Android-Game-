using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class AuthController : MonoBehaviour

{
    public string EmailInput; // variable that will hold email input
    public string PasswordInput; // variable that will hold password input
    public GameObject Email; // reference to the input field for email to get what the user text 
    public GameObject Password; // reference to input field for password 
    public Firebase.Auth.FirebaseAuth auth; // This is to access the Firebase.Auth.FirbaseAuth class

   
    
    public void Login() { // The function for Log-in 

        EmailInput = Email.GetComponent<InputField>().text;
        PasswordInput = Password.GetComponent<InputField>().text;
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance; //To be able to use te FirebaseAuth class since it is the gateway for all API calls.
        auth.SignInWithEmailAndPasswordAsync(EmailInput, PasswordInput).ContinueWith(task => {
            if (task.IsCanceled) { // if log-in got cancelled 
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) { // If there is a problem, such as the user not being registered in the first place.
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result; // User logs in successfully.
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
        

    }



    public void RegisterUser(){
        
        EmailInput = Email.GetComponent<InputField>().text; // getting the user input from input fields for email and password
        PasswordInput = Password.GetComponent<InputField>().text;

        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(EmailInput, // calling the creat user task, with user inputs as parameters
                PasswordInput).ContinueWith((task => { 

                    if(task.IsCanceled) { // if task got cancelled 

                        Firebase.FirebaseException e =   // gets the exception 
                        task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                        GetErrorMessage((AuthError)e.ErrorCode); // outputs the meaning of the error

                        return; // leaves function 

                    }

                    if (task.IsFaulted) { // if there is an error with the process of create user

                        Firebase.FirebaseException e = // gets exception
                        task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                        GetErrorMessage((AuthError)e.ErrorCode); // outputs meaning of the error

                        return; // leaves the function 

                    }

                    // Firebase user has been created.
                    Firebase.Auth.FirebaseUser newUser = task.Result; // Adds user to database
                    Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId); // prints success message with credentials 
                    
                }));
    }

    

    
    void GetErrorMessage(AuthError errorCode) { // this is the function that uses AuthError to put error codes into more detail

        string msg = "";

        msg = errorCode.ToString();

        print(msg); // prints the specific error 

    }

    
}

