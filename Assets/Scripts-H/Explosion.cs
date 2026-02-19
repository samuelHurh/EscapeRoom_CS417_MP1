using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 700f;
    public GameObject explosionParticles;
    public AudioSource explosionAudio;
    public float timer = 3f;

    public void StartExplosionTimer()
    {
        StartCoroutine(FuseRoutine());
    }

    private IEnumerator FuseRoutine()
    {
        yield return new WaitForSeconds(timer);
        Explode();
    }

    public void Explode()
    {
        if (explosionParticles != null)
        {
            GameObject effect = Instantiate(explosionParticles, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
        if (explosionAudio != null)
        {
            // We use PlayClipAtPoint so the sound continues even if the dynamite is Destroyed
            AudioSource.PlayClipAtPoint(explosionAudio.clip, transform.position);
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        Debug.Log("Found " + colliders.Length + " objects in blast radius!");
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
            
            if (hit.gameObject.name.Contains("Destroyable"))
            {
                hit.gameObject.SetActive(false); 
            }
        }

        Destroy(this.transform.gameObject);
    }
}