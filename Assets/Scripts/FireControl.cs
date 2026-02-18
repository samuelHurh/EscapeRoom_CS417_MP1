using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Attachment;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FireControl : MonoBehaviour
{
    private int currAmmoCount;
    
    [SerializeField] private Transform bulletSpawner;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce;
    [SerializeField] private TextMeshPro ammoCountDisplayer;
    [SerializeField] private Rigidbody myRB;

    private bool isLeftPrimaryGrab;

    private bool canFire;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currAmmoCount = 100;
        canFire = true;
        ammoCountDisplayer.text = currAmmoCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetHandRigidBody(Rigidbody rb, bool isLeft)
    {
        myRB = rb;
        isLeftPrimaryGrab = isLeft;
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
        Destroy(SpawnedBullet, 0.5f);
        myRB.AddForce(this.gameObject.transform.right * 1000f);
        SpawnedBullet.GetComponent<Rigidbody>().AddForce(bulletSpawner.right * -1 * bulletForce);
        currAmmoCount--;
        ammoCountDisplayer.text = currAmmoCount.ToString();

    }
}
