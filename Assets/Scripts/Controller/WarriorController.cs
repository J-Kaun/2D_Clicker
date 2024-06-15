using UnityEngine;

public class WarriorController : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnIdle()
    {
        anim.SetTrigger("Idle");
    }

    public void OnAttack()
    {
        anim.SetTrigger("Attack");
    }
}