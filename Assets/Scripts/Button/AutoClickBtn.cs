using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class AutoClickBtn : MonoBehaviour
{
    private bool isAutoIncreasing = false;
    private Coroutine autoIncreaseCoroutine;
    public int clickCount = 0;

    public Text increaseTxt;

    public void OnAutoBtn()
    {
        clickCount++;
        
        if (autoIncreaseCoroutine != null)
        {
            StopCoroutine(autoIncreaseCoroutine);
        }
        
        autoIncreaseCoroutine = StartCoroutine(AutoIncreaseGold());
        UpdateIncreaseTxt();
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

    private void UpdateIncreaseTxt()
    {
        increaseTxt.text = $"<b><color=green>Αυ°‘·®</color></b> : <b><color=red>{clickCount}/s</color></b>";
    }
}