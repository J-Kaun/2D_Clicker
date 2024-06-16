using System;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance { get; private set; }

    public Text goldTxt;
    private int gold = 0;
    private int goldIncreaseValue = 1;

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

    public void AttackIncreaseGold(int value = 1)
    {
        gold += value;
        UpdateGoldTxt();
    }

    public void UpgradeAttackIncreseGold()
    {
        gold += goldIncreaseValue;
        UpdateGoldTxt();
    }

    public void IncreaseGoldValue(int value)
    {
        goldIncreaseValue += value;
    }

    public void AutoIncreaseGold(int value)
    {
        gold += value;
        UpdateGoldTxt();
    }

    private void UpdateGoldTxt()
    {
        goldTxt.text = gold.ToString();
    }

    public int GetGoldIncreaseValue()
    {
        return goldIncreaseValue;
    }
}