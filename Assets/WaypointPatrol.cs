using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WaypointPatrol : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int m_currentindex;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            m_currentindex = (m_currentindex+1)%waypoints.Length;
            agent.SetDestination(waypoints[m_currentindex].position);
        }
    }
}
