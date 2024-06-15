using System;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance { get; private set; }

    public Text goldTxt;
    private int gold = 0;

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

    private void Start()
    {
        UpdateGoldTxt();
    }

    public void IncreaseGold()
    {
        gold++;
        UpdateGoldTxt();
    }

    private void UpdateGoldTxt()
    {
        goldTxt.text = gold.ToString();
    }
}