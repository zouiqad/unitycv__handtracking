using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb : MonoBehaviour
{
    [SerializeField] public ColorEnum.Color bombColor;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int TimeBeforeExplosion = 10;
    [SerializeField] public bool secured = false; // bomb is secured by player when bomb is in correct zone

    private bool exploded = false;
    public bool isGrabbed = false;
    // get navmeshagent
    public NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource.time = 0.0f; // start sound at 4 seconds
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            agent.enabled = false;
        }
        else
        {
            agent.enabled = exploded ? false : true; // disable navmeshagent if bomb is exploded
        }
    }

    // count 10 seconds before explosion
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(TimeBeforeExplosion);
        if (!secured) // if bomb is not secured explode
        {
            Explode();
        }
    }

    // explode
    void Explode()
    {
        exploded = true;
        audioSource.Play();
        // when sound is finished destroy bomb
        Destroy(gameObject, 1.5f);
    }
    public void Grab()
    {
        if (!secured)
        {
        isGrabbed = true;
        }
    }
    public void Release()
    {
        isGrabbed = false;
    }
}
