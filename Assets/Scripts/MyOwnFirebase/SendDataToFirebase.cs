using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDataToFirebase : MonoBehaviour
{
    private ClickMultiplier clickMultiplier;
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
        clickMultiplier = FindObjectOfType<ClickMultiplier>();
        score = FindObjectOfType<clickerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(SendToFirebase), 0.1f);
    }

    private void SendToFirebase()
    {
        DataStructure userData = new DataStructure();

        userData.clickMultiplier = clickMultiplier.clickMultiplier;
        userData.passiveIncome = passiveIncome.passiveIncome;
        userData.score = score.score;

        string json = JsonUtility.ToJson(userData);

        db.Child("users").Child(auth.CurrentUser.UserId).SetRawJsonValueAsync(json);


    }
}
