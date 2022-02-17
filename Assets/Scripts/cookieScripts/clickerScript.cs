using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickerScript : MonoBehaviour
{
    public float score;

    public Text scoreText;
    public GameObject cookie;

    private ClickMultiplier clicking;

    // Start is called before the first frame update
    void Start()
    {
        clicking = FindObjectOfType<ClickMultiplier>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("Score: {0:0.000}", score);
    }
    public void getScoreOnCookieClick()
    {
        score += clicking.clickMultiplier;
    }
}
