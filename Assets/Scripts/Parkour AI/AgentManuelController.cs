using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManuelController : MonoBehaviour
{
    private Transform[] WayPoints;

    public Transform[] finishPoints;
    private CharacterController controller;
    private int finishPoint;

    private float speed = 12f;


    [Header("LayerMasks")]
    public LayerMask walkableMask;
    public LayerMask jumpableMask;




    void Start()
    {
        finishPoint = Random.Range(0, 3);
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // float distance = Vector3.Distance(gameObject.transform.position, finishPoints[finishPoint].position);
        bool groundedPlayer = controller.isGrounded;
        Debug.Log(groundedPlayer);

        var distance = gameObject.transform.position - finishPoints[finishPoint].position;

        if (distance.magnitude > 1f)
        {
            distance = distance.normalized * speed;
            controller.Move(-distance * Time.deltaTime);
        }
        else
        {
            // controller.stepOffset();
        }

    }
}
