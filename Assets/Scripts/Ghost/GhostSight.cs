using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostSight : MonoBehaviour
{
    public float FOVAngle = 110f;
    public bool playerInSight;
    public Vector3 lastSighting;
    public GhostAI ghostAI;
    public float sphereRadius = 1f;

    private NavMeshAgent nav;
    private SphereCollider col;
    private LastPlayerSighting lastPlayerSighting;
    private GameObject player;
    private Vector3 previousSighting;

    private void Awake()
    {
        //When AI awakes, gets the navmesh, the attached sphere collider,
        //A default location set way off the map so it doesn't immediately chase something,
        //The player that it will be looking for,
        //And then sets its last sighting of the player to the far off place so it doesn't start chasing immediately.
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag("GameController").GetComponent<LastPlayerSighting>();
        player = GameObject.FindGameObjectWithTag("Player");

        lastSighting = lastPlayerSighting.resetPosition;
        previousSighting = lastPlayerSighting.resetPosition;
    }

    private void Update()
    {
        if (lastPlayerSighting.position != previousSighting)
        {
            lastSighting = lastPlayerSighting.position;
        }

        previousSighting = lastPlayerSighting.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInSight = false;

            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            
            if (angle < FOVAngle * 0.5f)
            {
                Debug.Log("In range");
                RaycastHit hit;

                if (Physics.SphereCast(transform.position + transform.up, 2f, direction.normalized, out hit, col.radius))
                {
                    if (hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        lastPlayerSighting.position = player.transform.position;
                        Debug.DrawLine(transform.position + transform.up, player.transform.position, Color.red);
                        ghostAI.Chasing();
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;
        }
    }
}
