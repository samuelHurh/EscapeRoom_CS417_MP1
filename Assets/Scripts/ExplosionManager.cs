using UnityEngine;
using System.Collections.Generic;

public class ExplosionManager : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    private bool isTNTThere;
    public GameObject explosionParticles;
    public AudioSource explosionAudio;
    public Transform explosionTransform;

    public SpawnManager smRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isTNTThere = false;
    }


    public void TNTPlaced()
    {
        isTNTThere = true;
    }

    public void TryExplode()
    {
        if (isTNTThere)
        {
            foreach (var item in items)
            {
                item.SetActive(false);
            }
            if (explosionParticles != null)
        {
            GameObject effect = Instantiate(explosionParticles, explosionTransform.position, Quaternion.identity);
                Destroy(effect, 5f);
            }
            if (explosionAudio != null)
            {
                // We use PlayClipAtPoint so the sound continues even if the dynamite is Destroyed
                AudioSource.PlayClipAtPoint(explosionAudio.clip, transform.position);
            }
            smRef.StartSpawning();
        }
    }
}
