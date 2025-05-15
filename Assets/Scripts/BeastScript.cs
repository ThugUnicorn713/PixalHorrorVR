using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class BeastScript : MonoBehaviour
{
    public float wanderRadius = 80f;
    public float wanderInterval = 3f;
    NavMeshAgent agent;


    public static BeastScript instance;

    public static BeastScript GetInstance()
    {
        return instance;
    }


    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }

        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(SetRandomPoint), 0f, wanderInterval);
         
    }

    void SetRandomPoint()
    {
        Vector3 randomPoint = Random.insideUnitSphere * wanderRadius;
        randomPoint += transform.position;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }

    }

     public void GoToPlayer(Vector3 nextPos)
     {
        agent.SetDestination(nextPos);
        Debug.Log(" Beast is coming for me!");

     } 
    
    public void GoToObject(Vector3 nextPos)
    {
        agent.SetDestination(nextPos);
        Debug.Log(" Beast is going to object!");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //end Scene

            Debug.Log("Beast killed the player!");
        }
    }
}
