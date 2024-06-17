using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  static GameManager Instance;

    public ParticleSystem EffectParticle;

    private void Awake()
    {
        Instance = this;

        EffectParticle = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
    }
}
