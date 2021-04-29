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
    public float searchArea = 20f;
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
    public void Start()
    {
        ResetWaypoints();
        agent = GetComponent<NavMeshAgent>();
        GoToNextWaypoint();
    }
    public void ResetWaypoints()
    {
        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            waypoints.Add(waypoint.transform);
        }
    }
    public void RemoveAndGoToNextWaypoint()
    {
        waypoints.Remove(waypoints[currentWaypoint]);
        currentWaypoint = Random.Range(0, waypoints.Count);
        agent.SetDestination(waypoints[currentWaypoint].position);
    }
    public void InsertWaypointAndHidingWaypoint()
    {
        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            float distance = Vector3.Distance(waypoint.gameObject.transform.position, transform.position);
            if(distance < searchArea)
            {
                gameObject.GetComponent<EnemyStats>().Searching = true;
                waypoints.Add(waypoint.gameObject.transform);
            }
        }
    }
}
