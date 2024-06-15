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

    public void OnAutoBtn()
    {
        clickCount++;
        
        if (autoIncreaseCoroutine != null)
        {
            StopCoroutine(autoIncreaseCoroutine);
        }
        
        autoIncreaseCoroutine = StartCoroutine(AutoIncreaseGold());
        UpdateIncreaseGoldTxt();
        UpdateIncreaseLevelTxt();
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
}