using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendDataToFirebase : MonoBehaviour
{
    ClickMultiplier clickMultiplier;
    private PassiveIncome passiveIncome;
    private clickerScript score;

    DatabaseReference db;
    FirebaseAuth auth;

   
    // Start is called before the first frame update
    void Start()
    {
        auth = auth = FirebaseAuth.DefaultInstance;
        db = FirebaseDatabase.DefaultInstance.RootReference;

        passiveIncome = FindObjectOfType<PassiveIncome>();
        score = FindObjectOfType<clickerScript>();
        InvokeRepeating(nameof(SendToFirebase), 0, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SendToFirebase()
    {
        //DataStructure userData = new DataStructure();

        //FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(false);

        //userData.clickMultiplier = DataStructure.Instance.clickMultiplier;
        //userData.passiveIncome = passiveIncome.passiveIncome;
        //userData.score = score.score;

        string json = JsonUtility.ToJson(DataStructure.Instance);

        db.Child("users").Child(auth.CurrentUser.UserId).SetRawJsonValueAsync(json);


    }
}
