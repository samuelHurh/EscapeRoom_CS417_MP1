using UnityEngine;
using TMPro;

public class FireControl : MonoBehaviour
{
    private int currAmmoCount;
    
    [SerializeField] private Transform bulletSpawner;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce;
    [SerializeField] private TextMeshPro ammoCountDisplayer;

    private bool canFire;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currAmmoCount = 0;
        canFire = true;
        ammoCountDisplayer.text = currAmmoCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementAmmoCount()
    {
        currAmmoCount += 1;
        ammoCountDisplayer.text = currAmmoCount.ToString();
    }

    public void EnableFire()
    {
        canFire = true;
    }

    public void Fire()
    {
        canFire = false;
        if (currAmmoCount <= 0)
        {
            Debug.Log("out of ammo");
            return;
        }
        GameObject SpawnedBullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        Destroy(SpawnedBullet, 1f);
        SpawnedBullet.GetComponent<Rigidbody>().AddForce(bulletSpawner.forward * -1 * bulletForce);
        currAmmoCount--;
        ammoCountDisplayer.text = currAmmoCount.ToString();

    }
}
