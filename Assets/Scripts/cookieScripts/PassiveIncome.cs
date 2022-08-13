using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveIncome : MonoBehaviour
{
    public float passiveIncome = 0;

    public Text passiveIncomeText;
    private clickerScript score;
    void Start()
    {
        score = FindObjectOfType<clickerScript>();
        passiveIncome = DataStructure.Instance.passiveIncome;
        passiveIncomeText.text = string.Format("PassiveIncome: {0:0.000}", passiveIncome);
    }

    // Update is called once per frame
    void Update()
    {
        score.score += passiveIncome * Time.deltaTime;
    }

    public void AddpassiveIncome(float addPassiveIncome, float itemCost)
    {
        passiveIncome += addPassiveIncome;
        score.score -= itemCost;
        // itemCost = itemCostToItem.addCostToItem;
        passiveIncomeText.text = string.Format("PassiveIncome: {0:0.000}", passiveIncome);
        DataStructure.Instance.passiveIncome = passiveIncome;
    }
}
