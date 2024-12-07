using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{   
    [SerializeField] private Transform _location;
    NavMeshAgent agent;
    Animator animator;
    private bool jump = false;
    public float runCooldown;

    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isRunning", false);
        // idle animasyon
        if (runCooldown < Time.time)
        {
            agent.SetDestination(_location.transform.position);
            animator.SetBool("isRunning", true);
        }
        
        // NavMeshAgent zýplama animasyonu
        if (agent.isOnOffMeshLink)
        {
            var meshlink = agent.currentOffMeshLinkData;
            if (!jump && meshlink.offMeshLink.area == NavMesh.GetAreaFromName("Start"))
            {
                animator.SetBool("Jump",true);              
                animator.SetBool("isRunning", false);
                JumpAnimation();
                jump = true;
            }
        }
        else
        {
            jump = false;
        }            
    }

    public void JumpAnimation()
    {
        animator.SetInteger("JumpIndex", Random.Range(0, 4));
        animator.SetTrigger("Jump");
    }
}
