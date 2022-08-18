using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMultiplier : MonoBehaviour
{
    public float clickMultiplier;
    public float amountOfClicks;
    public float clickerCost;

    private clickerScript score;
    private addCost itemCostToItem;
    private PassiveIncomeMeny PassiveIncomeMeny;
    void Start()
    {
        clickMultiplier = DataStructure.Instance.clickMultiplier;
        PassiveIncomeMeny = FindObjectOfType<PassiveIncomeMeny>();
        score = FindObjectOfType<clickerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(DataStructure.Instance.clickMultiplier);
    }

    public void moreClicksPerClick()
    {
        if (score.score >= clickerCost)
        {
            clickMultiplier += amountOfClicks;
            score.score -= clickerCost;
            DataStructure.Instance.clickMultiplier = clickMultiplier;
        }
    }
}
