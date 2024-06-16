using System;
using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class AutoClickBtn : MonoBehaviour
{
    private bool isAutoIncreasing = false;
    private Coroutine autoIncreaseCoroutine;
    public int clickCount = 0;

    public Text increaseGoldTxt;
    public Text increaseLevelTxt;

    public int autoClickCost;
    public Text costTxt;

    public GameObject NotEnoughGoldUI;

    public void OnAutoBtn()
    {
        autoClickCost = 10 + (clickCount * clickCount * 13);
        
        if (GoldManager.Instance.HasEnoughGold(autoClickCost))
        {
            GoldManager.Instance.SpendGold(autoClickCost);

            clickCount++;

            if (isAutoIncreasing)
            {
                StopCoroutine(autoIncreaseCoroutine);
            }

            autoIncreaseCoroutine = StartCoroutine(AutoIncreaseGold());

            UpdateIncreaseGoldTxt();
            UpdateIncreaseLevelTxt();
            UpdateCostTxt();
        }
        else
        {
            NotEnoughGoldUI.SetActive(true);
        }
    }

    private IEnumerator AutoIncreaseGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GoldManager.Instance.AutoIncreaseGold(clickCount);
        }
    }

    private void OnDisable()
    {
        if (isAutoIncreasing)
        {
            StopCoroutine(autoIncreaseCoroutine);
            isAutoIncreasing = false;
        }
    }

    private void UpdateIncreaseGoldTxt()
    {
        increaseGoldTxt.text = $"<b><color=green>Αυ°‘·®</color></b> : <b><color=red>{clickCount}/s</color></b>";
    }

    private void UpdateIncreaseLevelTxt()
    {
        increaseLevelTxt.text = $"Lv. <color=blue>{clickCount}</color>";
    }

    private void UpdateCostTxt()
    {
        costTxt.text = $"<color=black>Cost :</color> {10 + (clickCount * clickCount * 15)}";
    }
}