using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyGhost : MonoBehaviour
{
    public NavMeshAgent Ghost;
    public Transform playerTarget;
    public float playerDistance;
    public float awareAI = 10f;
    public float AIMovespeed;
    public float damping = 6.0f;

    public AudioClip ISeeYou;
    private AudioSource audioSource;

    public Transform[] navPoint;
    public int destPoint = 0;
    public Transform goal;

    private void Start()
    {
        Ghost = GetComponent<NavMeshAgent>();
        Ghost.destination = goal.position;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        playerDistance = Vector3.Distance(playerTarget.position, transform.position);

        if (playerDistance < awareAI)
        {
            LookAtPlayer();
            
            if (playerDistance > 2f)
            {
                Chase();
                PlayAudioClip(ISeeYou);
            }
            else
            {
                GotoNextPoint();
            }
        }

        if (Ghost.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }

    private void LookAtPlayer()
    {
        transform.LookAt(playerTarget);
    }

    private void GotoNextPoint()
    {
        if (navPoint.Length == 0)
        {
            return;
        }

        Ghost.destination = navPoint[destPoint].position;
        destPoint = (destPoint + 1) % navPoint.Length;
    }

    private void Chase()
    {
        transform.Translate(Vector3.forward * AIMovespeed * Time.deltaTime);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        SceneManager.LoadScene("GameOverScreen");
    //    }
    //}

    void PlayAudioClip(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            if (!audioSource.isPlaying) audioSource.PlayOneShot(clip);
        }
    }
}
