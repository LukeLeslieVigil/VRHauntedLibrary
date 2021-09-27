using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseWaitTime = 5f;
    public float patrolWaitTime = 1f;
    public Transform[] patrolWayPoints;

    public AudioClip ISeeYou;
    private AudioSource audioSource;

    private GhostSight ghostSight;
    private NavMeshAgent nav;
    private Transform player;
    private LastPlayerSighting lastPlayerSighting;
    private float chaseTimer;
    private float patrolTimer;
    private int wayPointIndex;

    private void Awake()
    {
        ghostSight = GetComponent<GhostSight>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerSighting = GameObject.FindGameObjectWithTag("GameController").GetComponent<LastPlayerSighting>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (ghostSight.playerInSight == true)
        {
            Chasing();
            Debug.Log("CHASING");
            PlayAudioClip(ISeeYou);
        }
        else
        {
            Patrolling();
        }
    }

    void Catching()
    {

    }

    public void Chasing()
    {
        Vector3 sightingDeltaPos = ghostSight.lastSighting - transform.position;
        if (sightingDeltaPos.sqrMagnitude > 4f)
        {
            nav.destination = ghostSight.lastSighting;
        }

        nav.speed = chaseSpeed;

        if (nav.remainingDistance < nav.stoppingDistance)
        {
            chaseTimer += Time.deltaTime;

            if (chaseTimer > chaseWaitTime)
            {
                lastPlayerSighting.position = lastPlayerSighting.resetPosition;
                ghostSight.lastSighting = lastPlayerSighting.resetPosition;
                chaseTimer = 0f;
            }
        }
        else
        {
            chaseTimer = 0f;
        }
    }

    void Patrolling()
    {
        nav.speed = patrolSpeed;

        if(nav.destination == lastPlayerSighting.resetPosition || nav.remainingDistance < nav.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;

            if(patrolTimer >= patrolWaitTime)
            {
                if (wayPointIndex == patrolWayPoints.Length - 1)
                {
                    wayPointIndex = 0;
                }
                else
                {
                    wayPointIndex++;
                }

                patrolTimer = 0f;
            }
        }
        else
        {
            patrolTimer = 0f;
        }

        nav.destination = patrolWayPoints[wayPointIndex].position;
    }

    void PlayAudioClip(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            if (!audioSource.isPlaying) audioSource.PlayOneShot(clip);
        }
    }
}
