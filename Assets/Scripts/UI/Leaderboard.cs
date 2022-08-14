using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
    DatabaseReference db;
    FirebaseAuth auth;

    public GameObject ScoreElement;
    public Transform scoreboardContent;
    // Start is called before the first frame update
    void Start()
    {
        auth = auth = FirebaseAuth.DefaultInstance;
        db = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreBoardButton()
    {
        StartCoroutine(LoadScoreBoardData());
    }

    private IEnumerator LoadScoreBoardData()
    {
        var task = db.Child("users").OrderByChild("score").GetValueAsync();

        yield return new WaitUntil(predicate: () => task.IsCompleted);

        if(task.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {task.Exception}");
        }
        else
        {
            DataSnapshot highscore = task.Result;

            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (DataSnapshot childsnapshot in highscore.Children.Reverse<DataSnapshot>())
            {
                string userName = childsnapshot.Child("userName").Value.ToString();
                float score = float.Parse(childsnapshot.Child("score").Value.ToString());

                GameObject scoreboardElement = Instantiate(ScoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScore(userName, score);
            }

            UIManager.instance.ScoreboardScreen();
        }
    }
}
