using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickerScript : MonoBehaviour
{
    public float score;

    public Text scoreText;
    public string name;
    public GameObject cookie;
    public Text userName;

    private ClickMultiplier clicking;

    // Start is called before the first frame update
    void Start()
    {
        clicking = FindObjectOfType<ClickMultiplier>();
        score = DataStructure.Instance.score;
        name = DataStructure.Instance.userName;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("Score: {0:0.0}", score);
        userName.text = name;
    }
    public void getScoreOnCookieClick()
    {
        score += clicking.clickMultiplier;
    }

    public void addScoreToPlayerData()
    {
        Debug.Log("Hej Hej Hej");
        score = PlayerData.data.score;
    }
}
