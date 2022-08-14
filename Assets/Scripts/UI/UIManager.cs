using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject scoreboardUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    //Functions to change the login screen UI

    public void ClearScreen() //Turn off all screens
    {
        scoreboardUI.SetActive(false);
    }
        public void ScoreboardScreen() //Scoreboard button
    {
        ClearScreen();
        scoreboardUI.SetActive(true);
    }
}