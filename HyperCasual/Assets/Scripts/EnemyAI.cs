using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform _location;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        agent.SetDestination (_location.transform.position);
    }
}
