using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonController : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnIdle()
    {
        anim.SetTrigger("Demon_Idle");
    }

    public void OnHit()
    {
        anim.SetTrigger("Demon_Hit");
    }
}
