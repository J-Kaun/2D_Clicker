using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUpgradeBtn : MonoBehaviour
{
    public int clickCount = 0;

    public Text increaseGoldTxt;
    public Text increaseLevelTxt;

    public Text costTxt;

    public GameObject NotEnoughGoldUI;

    public void OnDamageBtn()
    {
        int currentCost = CalculateCost(clickCount);
        
        if (GoldManager.Instance.HasEnoughGold(currentCost))
        {
            GoldManager.Instance.SpendGold(currentCost);

            clickCount++;
            int newIncreaseValue = clickCount;

            GoldManager.Instance.IncreaseGoldValue(newIncreaseValue);

            UpdateIncreaseGoldTxt();
            UpdateIncreaseLevelTxt();
            UpdateCostTxt();
        }
        else
        {
            NotEnoughGoldUI.SetActive(true);
        }
    }

    private int CalculateCost(int clickCount)
    {
        return 10 + (clickCount * clickCount * 7);
    }

    private void UpdateIncreaseLevelTxt()
    {
        increaseLevelTxt.text = $"Lv. <color=blue>{clickCount}</color>";
    }

    private void UpdateIncreaseGoldTxt()
    {
        increaseGoldTxt.text = $"<b><color=green>Αυ°‘·®</color></b> : <b><color=red>{1 + clickCount}</color></b>";
    }

    private void UpdateCostTxt()
    {
        costTxt.text = $"<color=black>Cost :</color> {10 + (clickCount * clickCount * 7)}";
    }
}
