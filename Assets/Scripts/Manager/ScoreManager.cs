using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text goldText;
    private int gold = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    public void OnAttackBtn()
    {
        gold++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        goldText.text = gold.ToString();
    }
}
