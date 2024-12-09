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
            Debug.Log("animasyon");
        }
        
        // NavMeshAgent zýplama animasyonu
        if (agent.isOnOffMeshLink)
        {
            var meshlink = agent.currentOffMeshLinkData;
            if (!jump && meshlink.offMeshLink.area == NavMesh.GetAreaFromName("Start"))
            {
                animator.SetBool("isRunning", false);
                jump = true;
                animator.SetBool("Jump",true);              
                JumpAnimation();
            }
        }
        else
        {
            jump = false;
            animator.SetBool("Jump", false);
            animator.SetBool("isRunning", true);
        }            
    }

    public void JumpAnimation()
    {
        animator.SetInteger("JumpIndex", Random.Range(0, 4));
        animator.SetTrigger("Jump");
    }
}
// oyun baþladýgýnda geri sayým eklenecek
