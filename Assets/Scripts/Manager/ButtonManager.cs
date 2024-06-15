using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance { get; private set; }

    private bool isAutoIncreasing = false;
    private Coroutine autoIncreaseCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnAttackBtn()
    {
        GoldManager.Instance.IncreaseGold();
    }

    public void OnAutoBtn()
    {
        if (isAutoIncreasing)
        {
            StopCoroutine(autoIncreaseCoroutine);
            isAutoIncreasing=false;
        }
        else
        {
            autoIncreaseCoroutine = StartCoroutine(AutoIncreaseGold());
            isAutoIncreasing = true;
        }
    }

    private IEnumerator AutoIncreaseGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GoldManager.Instance.IncreaseGold();
        }
    }
}