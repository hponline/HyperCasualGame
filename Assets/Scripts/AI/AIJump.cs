using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIJump : StateMachineBehaviour
{
    NavMeshAgent agent;
    float speed;
    // ziplarken ki hizi
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        speed = agent.speed;
        agent.speed = 3f;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.speed = speed;
    }
}
