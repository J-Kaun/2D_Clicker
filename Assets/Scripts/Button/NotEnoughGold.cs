using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughGold : MonoBehaviour
{
    public GameObject notEnoughGoldUI;
    
    public void OnNotEnoughGold()
    {
        notEnoughGoldUI.SetActive(false);
    }
}
