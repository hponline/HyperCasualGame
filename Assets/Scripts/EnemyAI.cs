using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{   
    [SerializeField] private Transform _location;
    NavMeshAgent agent;
    private bool zýpla = false;
    public float runCooldown;
    Animator animator;

    
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
        animator.SetInteger("JumpIndex", Random.Range(0, 4));
        animator.SetTrigger("Jump");
    }
}
