using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private void DestroyProgectile(Vector3 position, bool createFX)
    {
        if (createFX)
        {
            ParticleSystem particleSystem = GameManager.Instance.EffectParticle;

            particleSystem.transform.position = position;
            ParticleSystem.EmissionModule em = particleSystem.emission;
            ParticleSystem.MainModule mainModule = particleSystem.main;
            particleSystem.Play();
        }

        gameObject.SetActive(false);
    }
}