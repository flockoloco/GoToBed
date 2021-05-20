using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class enemyPresentationTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    bool oneTime = true;
    public WayPointInfo spawnPosition;
    public State searchState;
    public List<WayPointInfo> scriptedWayPoints;
    private GameObject enemySpawn;
    public WayPointInfo deathWayPoint;


    private void OnTriggerEnter(Collider other)
    {
        if (oneTime)
        {
            if ( other.tag == "Player")
            {
                enemySpawn =  Instantiate(enemyPrefab, spawnPosition.wpPosition,Quaternion.identity);
                enemySpawn.GetComponent<FiniteStateMachine>().CurrentState = searchState;
                enemySpawn.GetComponent<EnemyStats>().CurrentWaypoint = -1;
                enemySpawn.GetComponent<EnemyStats>().SearchWaypoints = scriptedWayPoints;
                enemySpawn.SetActive(true);
                enemySpawn.GetComponent<EnemyStats>().Agent = enemySpawn.GetComponent<NavMeshAgent>();
                Debug.Log(scriptedWayPoints[0].name + " before going into nextwaypointS");
                enemySpawn.GetComponent<EnemyStats>().GoToNextWaypoint(scriptedWayPoints);
                
                
                Debug.Log(enemySpawn.GetComponent<FiniteStateMachine>().CurrentState);
                oneTime = false;
            }
        }

    }
    private void Update()
    {
        if (enemySpawn)
        {
if (Vector3.Distance( enemySpawn.transform.position, deathWayPoint.wpPosition) < 2)
        {
            Destroy(enemySpawn.gameObject);
        }
        }
        
    }
}
