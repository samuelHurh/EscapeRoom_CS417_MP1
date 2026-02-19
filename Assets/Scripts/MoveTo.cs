using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetTarget(Transform targetTransform)
    {
        goal = targetTransform;
        if (agent != null && goal != null)
            agent.SetDestination(goal.position);
        StartCoroutine(Tick());
    }


    public IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (agent != null && goal != null)
                agent.SetDestination(goal.position);
        }
    }
}
