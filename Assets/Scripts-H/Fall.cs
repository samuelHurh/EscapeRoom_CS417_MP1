using UnityEngine;

public class PhysicsActivator : MonoBehaviour
{

    public GameObject dynamite;
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object touching us has the right tag
        if (collision.gameObject.name.Contains("Bullet"))
        {
            if (GetComponent<Rigidbody>() == null)
            {
                Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            }
        }
        if (collision.gameObject.name.Contains("Main"))
        {
            Destroy(gameObject);
            spawnDynamite();
        }
    }

    private void spawnDynamite()
    {
        if (dynamite != null)
        {
            Instantiate(dynamite, transform.position, transform.rotation);   
        }
    }
}