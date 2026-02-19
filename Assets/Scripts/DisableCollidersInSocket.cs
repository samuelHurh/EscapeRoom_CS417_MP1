using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisableCollidersInSocket : MonoBehaviour
{
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public List<Collider> colliders = new List<Collider>();

    public void DisableColliders()
    {
        foreach (var collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
