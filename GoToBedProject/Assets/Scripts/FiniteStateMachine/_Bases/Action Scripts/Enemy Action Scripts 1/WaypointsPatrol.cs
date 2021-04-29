using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointsPatrol : MonoBehaviour
{
    private NavMeshAgent agent;
    public List<Transform> waypoints = new List<Transform>();
    public int currentWaypoint;
    public Transform target;
    public void GoToNextWaypoint()
    {
        //select a random waypoint to go
        currentWaypoint = Random.Range(0, waypoints.Count);
        agent.SetDestination(waypoints[currentWaypoint].position);
    }
    public bool IsAtDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if ((!agent.hasPath) || (agent.velocity.sqrMagnitude == 0))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void GoToTarget()
    {
        agent.SetDestination(target.position);
    }

    public void StopAgent()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }
    void Start()
    {
        ResetWaypoints();
        agent = GetComponent<NavMeshAgent>();
        GoToNextWaypoint();
    }
    void ResetWaypoints()
    {
        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            waypoints.Add(waypoint.transform);
        }
    }
}
