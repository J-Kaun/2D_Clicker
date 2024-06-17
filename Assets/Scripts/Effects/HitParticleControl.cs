using UnityEngine;

public class HitParticleControl : MonoBehaviour
{
    [SerializeField] private bool createBloodOnAttack = true;
    [SerializeField] private ParticleSystem hitParticleSystem;

    public void CreateDustParticles()
    {
        if (createBloodOnAttack)
        {
            hitParticleSystem.Stop();
            hitParticleSystem.Play();
        }
    }
}