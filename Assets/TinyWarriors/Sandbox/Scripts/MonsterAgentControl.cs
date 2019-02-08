using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAgentControl : MonoBehaviour
{

	public Transform home;
	private NavMeshAgent agent;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination((home.position));
    }

    
    void Update()
    {
        
    }
}
