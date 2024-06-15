using UnityEngine;

public class AttackBtn: MonoBehaviour
{
    public int IncreaseValue = 1;
    
    public void OnAttackBtn()
    {
        GoldManager.Instance.IncreaseGold(IncreaseValue);
    }
}