using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveIncomeMeny : MonoBehaviour
{
    public float itemCost;
    public float addPassiveIncome;
    
    public Text passiveIncomeText;

    private clickerScript score;
    private PassiveIncome passiveIncome;
    void Start()
    {
        passiveIncome = FindObjectOfType<PassiveIncome>();
        score = FindObjectOfType<clickerScript>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void passiveIncomeToItem()
    {
        if(score.score >= itemCost)
        {
            passiveIncome.AddpassiveIncome(addPassiveIncome, itemCost);
            
        }
    }
}