using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentscript : MonoBehaviour
{
    [SerializeField] Transform endpoint;
    [SerializeField] float speed;
    public float health;
    NavMeshAgent nma;
    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        nma.speed = speed;
        endpoint = GameObject.FindGameObjectWithTag("endpoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        nma.destination = endpoint.position;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void damage(float points)
    {
        health -= points;
    }

    public void slowdown(float points)
    {
        nma.speed = nma.speed * points;
    }

    public void speedup(float points)
    {
        nma.speed = nma.speed / points;
    }
}
