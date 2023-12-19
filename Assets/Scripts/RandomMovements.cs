using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 randomDestination;
    public float minDistance = 5f;
    public float maxDistance = 15f;
    private bool isMoving = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        if (!agent.pathPending && !isMoving)
        {
            StartCoroutine(MoveRandom());
        }
    }

    IEnumerator MoveRandom()
    {
        isMoving = true;
        yield return new WaitForSeconds(Random.Range(1f, 3f)); // Temps d'attente entre chaque déplacement
        SetRandomDestination();
        isMoving = false;
    }

    void SetRandomDestination()
    {
        if (agent.enabled == true)
        {  
        Vector3 randomDirection = Random.insideUnitSphere * Random.Range(minDistance, maxDistance);
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, maxDistance, NavMesh.AllAreas);
        randomDestination = hit.position;
        agent.SetDestination(randomDestination);
        }
    }
}
