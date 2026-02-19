using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class BreakSystem : MonoBehaviour
{
    public List<GameObject> firstHit = new List<GameObject>();
    public List<GameObject> secondHit = new List<GameObject>();
    public List<GameObject> thirdHit = new List<GameObject>();
    public AudioSource breakAudio;

    private int hitCount;

    private bool canHit;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitCount = 0;
        canHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "axe" && canHit)
        {
            AudioSource.PlayClipAtPoint(breakAudio.clip, transform.position);
            canHit = false;
            hitCount += 1;
            if (hitCount == 1)
            {
                foreach (var item in firstHit)
                {
                    item.SetActive(true);
                }
            } else if (hitCount == 2)
            {
                foreach (var item in secondHit)
                {
                    item.SetActive(true);
                }
            } else if (hitCount == 3)
            {
                foreach (var item in thirdHit)
                {
                    item.SetActive(true);
                }
            } else
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "axe")
        {
            StartCoroutine(HitCooldown());
        }
    }

    public IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canHit = true;
    }
}
