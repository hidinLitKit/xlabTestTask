using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    public float renderFogDist;
    public GameObject RainDrops;
    void Awake()
    {
        renderFogDist = RenderSettings.fogEndDistance;
    }

    public void ActivateParticle()
    {
        RainDrops.GetComponent<ParticleSystem>().Play();
    }
    public void DeactivateParticle()
    {
        RainDrops.GetComponent<ParticleSystem>().Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            RenderSettings.fogEndDistance = 19f;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            RenderSettings.fogEndDistance = renderFogDist;
    }
}
