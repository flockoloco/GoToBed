using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Spider/Entry Search Action")]
public class SpiderSearchEntryAction : Action
{
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {
        if (enemyStats.SearchWaypoints != null) //remove later
        {
            enemyStats.SearchWaypoints.Clear();
        }
        enemyStats.SearchWaypoints.Add(new WayPointInfo(0,enemyStats.Target.gameObject.transform.position));


        float closestWaypoint = Mathf.Infinity;
        GameObject closestWaypointObject = null;
        foreach (GameObject waypoint in enemyStats.ListMainWaypoints)
        {
            float distance = Vector3.Distance(waypoint.gameObject.transform.position, enemyStats.Target.gameObject.transform.position);
            if (distance < closestWaypoint)
            {
                closestWaypoint = distance;
                closestWaypointObject = waypoint;
            }
        }
        foreach (Transform childWaypoint in closestWaypointObject.GetComponent<MainWaypoint>().waypoints)
        {
            enemyStats.Searching = true;
            enemyStats.SearchWaypoints.Add(childWaypoint.gameObject.GetComponent<WayPointInfo>());
        }
        enemyStats.CurrentWaypoint = int.MaxValue;
        enemyStats.GoToNextWaypoint(enemyStats.SearchWaypoints);
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
