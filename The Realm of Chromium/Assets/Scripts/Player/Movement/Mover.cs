using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Mover : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] Vector3 destination;
    Ray lastRay;
    RaycastHit lastRayHit;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
    }

    void MoveToCursor()
    {
        lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(lastRay, out lastRayHit);
        destination = lastRayHit.point;
        agent.SetDestination(destination);
    }

}
