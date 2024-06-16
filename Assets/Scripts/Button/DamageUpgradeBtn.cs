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

    public void OnDamageBtn()
    {
        clickCount++;
        int newIncreaseValue = 1;

        GoldManager.Instance.IncreaseGoldValue(newIncreaseValue);

        UpdateIncreaseGoldTxt();
        UpdateIncreaseLevelTxt();
    }

    private void UpdateIncreaseLevelTxt()
    {
        increaseLevelTxt.text = $"Lv. <color=blue>{clickCount}</color>";
    }

    private void UpdateIncreaseGoldTxt()
    {
        increaseGoldTxt.text = $"<b><color=green>Αυ°‘·®</color></b> : <b><color=red>{1 + clickCount}</color></b>";
    }
}
