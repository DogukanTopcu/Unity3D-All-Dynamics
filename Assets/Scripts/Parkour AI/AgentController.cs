using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Transform[] finishPoints;
    private CharacterController controller;


    private NavMeshAgent agent;
    private int finishPoint;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        finishPoint = Random.Range(0, 3);
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = finishPoints[finishPoint].position;


    }
}
