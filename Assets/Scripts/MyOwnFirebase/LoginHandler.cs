using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginHandler : MonoBehaviour
{
    public TMP_InputField email, password;

    DatabaseReference db;
    FirebaseAuth auth;
    // Start is called before the first frame update
    void Start()
    {
        auth = auth = FirebaseAuth.DefaultInstance;
        db = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    public void Login


}
