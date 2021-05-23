using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Enemy/Entry Search")]
public class EnemySearchEntry : Action
{

    [SerializeField]
    EnemySearch _enemySearch;
    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats)
    {
        throw new System.NotImplementedException();
    }

    public override void Act(FiniteStateMachine fsm, EnemyStats enemyStats)
    {

        _enemySearch.animationTimer = 0;
        enemyStats.TurnOffThenTurnOnAnimation("Walking");
        if (enemyStats.SearchWaypoints != null) //remove later
        {
            enemyStats.SearchWaypoints.Clear();
        }
        enemyStats.PlayerWayPoint.transform.position = enemyStats.Target.transform.position;
        enemyStats.PlayerWayPoint.UpdatePosition();


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
        bool pickedOne = false;
        foreach (Transform childWaypoint in closestWaypointObject.GetComponent<MainWaypoint>().waypoints) //first check if theres oneso close that the enemy NEEDS to go check it
        {
            Vector3 calculation = (childWaypoint.position - enemyStats.PlayerWayPoint.wpPosition);
            calculation.y = 0;

            if ( calculation.magnitude < 2)
            {
                enemyStats.SearchWaypoints.Add(childWaypoint.gameObject.GetComponent<WayPointInfo>());
                pickedOne = true;
            }
        }
        if (pickedOne.Equals(false))
        {
            enemyStats.SearchWaypoints.Add(enemyStats.PlayerWayPoint);
        }

        foreach (Transform childWaypoint in closestWaypointObject.GetComponent<MainWaypoint>().waypoints) //then give a chance for each, rn it can repeat one if its already picked above, but it wont matter as the player is caught anyways
        {
            if (Random.Range(0,1) < 0.4f)
            {
                enemyStats.SearchWaypoints.Add(childWaypoint.gameObject.GetComponent<WayPointInfo>());
            }
        }

        enemyStats.CurrentWaypoint = int.MaxValue;
        enemyStats.GoToNextWaypoint(enemyStats.SearchWaypoints);
    }

    public override void Act(FiniteStateMachine fsm, PlayerStats playerStats, EnemyStats[] allEnemyStats)
    {
        throw new System.NotImplementedException();
    }
}
