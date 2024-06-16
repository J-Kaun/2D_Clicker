using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinQuestBtn : MonoBehaviour
{
    private bool isAutoIncreasing = false;
    private Coroutine autoIncreaseCoroutine;
    public int clickCount = 0;

    public Text increaseGoldTxt;
    public Text increaseLevelTxt;

    public int QuestCost;
    public Text costTxt;

    public GameObject NotEnoughGoldUI;

    public void OnQuestBtn()
    {
        QuestCost = 10 + (clickCount * clickCount * 21);

        if (GoldManager.Instance.HasEnoughGold(QuestCost))
        {
            GoldManager.Instance.SpendGold(QuestCost);

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
            yield return new WaitForSeconds(5f);
            GoldManager.Instance.AutoIncreaseGold(clickCount * 10);
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
        increaseGoldTxt.text = $"<b><color=green>Αυ°‘·®</color></b> : <b><color=red>{clickCount * 10}/5s</color></b>";
    }

    private void UpdateIncreaseLevelTxt()
    {
        increaseLevelTxt.text = $"Lv. <color=blue>{clickCount}</color>";
    }

    private void UpdateCostTxt()
    {
        costTxt.text = $"<color=black>Cost :</color> {10 + (clickCount * clickCount * 21)}";
    }
}
