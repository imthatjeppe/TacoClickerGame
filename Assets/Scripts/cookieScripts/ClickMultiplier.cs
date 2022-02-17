using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMultiplier : MonoBehaviour
{
    public float clickMultiplier;
    public float amountOfClicks;

    private clickerScript score;
    private addCost itemCostToItem;
    private PassiveIncomeMeny PassiveIncomeMeny;
    void Start()
    {
        clickMultiplier = 1;
        PassiveIncomeMeny = FindObjectOfType<PassiveIncomeMeny>();
        score = FindObjectOfType<clickerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moreClicksPerClick()
    {
        if (score.score >= PassiveIncomeMeny.itemCost)
        {
            clickMultiplier +=  amountOfClicks;
            score.score -= PassiveIncomeMeny.itemCost;
        }
    }
}
