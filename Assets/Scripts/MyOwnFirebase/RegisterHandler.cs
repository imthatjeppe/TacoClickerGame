using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegisterHandler : MonoBehaviour
{
    public TMP_InputField email, userName, password;

    DatabaseReference db;
    FirebaseAuth auth;

    // Start is called before the first frame update
    void Start()
    {
        auth = auth = FirebaseAuth.DefaultInstance;
        db = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void RegisterUser()
    {
        DataStructure userData = new DataStructure();
        FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(false);

        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text);

        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWithOnMainThread(task =>
        {
            userData.userName = userName.text;
            userData.clickMultiplier = 1;
            
            string json = JsonUtility.ToJson(userData);

            db.Child("users").Child(auth.CurrentUser.UserId).SetRawJsonValueAsync(json);
            auth.SignOut();

        });
    }
   
}
