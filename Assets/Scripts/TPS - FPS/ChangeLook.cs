using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook : MonoBehaviour
{
    [SerializeField] private Camera fps;
    [SerializeField] private Camera tps;


    void Start()
    {
        fps = transform.GetChild(2).transform.GetChild(0).GetComponent<Camera>();
        tps = transform.GetChild(0).GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fps.depth < tps.depth)
            {
                fps.depth = 2;
                tps.depth = 1;
            }
            else
            {
                fps.depth = 1;
                tps.depth = 2;
            }
        }
    }
}
