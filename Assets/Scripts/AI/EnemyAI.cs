using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{   
    [SerializeField] private Transform _location;
    NavMeshAgent agent;
    Animator animator;
    private bool jump = false;

    [Header("Geri Sayým")]
    public int countdownStartTimer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        StartCoroutine(CountDownStartToGo());
    }

    private void Update()
    {       
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

    public void Run()
    {
        agent.SetDestination(_location.transform.position);
        animator.SetBool("isRunning", true);
    }

    IEnumerator CountDownStartToGo()
    {
        while (countdownStartTimer > 0)
        {           
            yield return new WaitForSeconds(1f);
            countdownStartTimer--;
            
        }
        yield return new WaitForSeconds(1f);
        Run();
    }
}

