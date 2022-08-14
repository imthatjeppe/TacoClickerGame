using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text scoreText;
   
    public void NewScore(string username, float score)
    {
        usernameText.text = username.ToString();
        scoreText.text = score.ToString();
    }
}
