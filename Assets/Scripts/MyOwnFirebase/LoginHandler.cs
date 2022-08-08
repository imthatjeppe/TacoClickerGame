using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginHandler : MonoBehaviour
{
    public TextMeshProUGUI outputText;
    public TMP_InputField email, password;

    public Button playButton;

    DatabaseReference db;
    FirebaseAuth auth;
    // Start is called before the first frame update
    void Start()
    {
        auth = auth = FirebaseAuth.DefaultInstance;
        db = FirebaseDatabase.DefaultInstance.RootReference;
        playButton.interactable = false;
    }

    // Update is called once per frame
    public void LoginUser()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            //FirebaseUser newUser = task.Result;
            //Debug.LogFormat("User signed in successfully: {0} ({1})",
            //newUser.DisplayName, newUser.UserId);
            db.Child("users").Child(auth.CurrentUser.UserId).GetValueAsync().ContinueWithOnMainThread(JsonInfo =>
            {
                //Debug.Log(JsonInfo.Result.GetRawJsonValue());
                DataStructureStyle userData = JsonUtility.FromJson<DataStructureStyle>(JsonInfo.Result.GetRawJsonValue());
                
                DataStructure.Instance.userName = userData.userName;
                DataStructure.Instance.score = userData.score;
                DataStructure.Instance.clickMultiplier = userData.clickMultiplier;
                DataStructure.Instance.passiveIncome = userData.passiveIncome;
            });
                 PlayerDataLoaded();
        });
    }

    public void PlayerDataLoaded()
    {
        playButton.interactable = true;
    }
}
