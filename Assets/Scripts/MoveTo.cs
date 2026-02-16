using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
        //agent.destination = goal.position;
    }

    public void SetTarget(Transform targetTransform)
    {
        goal = targetTransform;
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.destination != null)
        {
            agent.destination = goal.position;
        }
        
    }

    public IEnumerator Tick()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);

        }
    }

    
}
