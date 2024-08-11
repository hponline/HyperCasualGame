using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    

    private NavMeshAgent agent;
    [SerializeField] private Transform _location;

    private bool zýpla = false;

    Animator animator;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        agent.SetDestination (_location.transform.position);
        animator.SetBool("isRunning", true);
        if (agent.isOnOffMeshLink)
        {
            var meshlink = agent.currentOffMeshLinkData;

            if (!zýpla && meshlink.offMeshLink.area == NavMesh.GetAreaFromName("Start"))
            {
                JumpAnimation();
                animator.SetBool("Jump",true);
                animator.SetBool("isRunning", false);
                zýpla = true;
            }
        }
        else
        {
            zýpla = false;
        }            
    }

    public void JumpAnimation()
    {
        animator.SetInteger("JumpIndex", Random.Range(0, 3));
        animator.SetTrigger("Jump");
    }
}
