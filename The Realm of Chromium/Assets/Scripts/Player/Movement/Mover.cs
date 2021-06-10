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

    public LayerMask ground;

    [SerializeField] GameObject playerModel;

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
        else if(Input.GetMouseButton(0))
        {
            MoveToCursor();
        }

        UpdateAnimatoion();
    }

    void MoveToCursor()
    {
        lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(lastRay, out lastRayHit, ground);
        destination = lastRayHit.point;
        agent.SetDestination(destination);     
    }

    void UpdateAnimatoion()
    {
        Vector3 velocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;

        playerModel.GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
    }

}
