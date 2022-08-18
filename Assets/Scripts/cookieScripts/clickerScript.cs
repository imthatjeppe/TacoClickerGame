using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickerScript : MonoBehaviour
{
    public float score;

    public Text scoreText;
    public Text userName;
    public GameObject cookie;

    private ClickMultiplier clicking;

    // Start is called before the first frame update
    void Start()
    {
        clicking = FindObjectOfType<ClickMultiplier>();
        score = DataStructure.Instance.score;
        userName.text = string.Format("Username", DataStructure.Instance.userName);
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("Score: {0:0.0}", score);
        DataStructure.Instance.score = score;

        Debug.Log(clicking.clickMultiplier);
    }
    public void getScoreOnCookieClick()
    {
        score += DataStructure.Instance.clickMultiplier;
    }
}
