using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{

    public Transform spawnTransform;
    public GameObject enemyPrefab;
    public GameObject PlayerRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(4f);
            GameObject a = Instantiate(enemyPrefab, spawnTransform.position, spawnTransform.rotation);
            a.GetComponent<MoveTo>().SetTarget(PlayerRef.transform);
            Debug.Log("Spawning Enemy");
        }
    }


}
