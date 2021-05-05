using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : Stats
{
    [SerializeField]
    private float _visionDetection;
    [SerializeField]
    private float _soundDetection;
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private bool _searching;
    public GameObject bolinha;
    private NavMeshAgent _agent;
    [SerializeField]
    private List<Transform> _defaultWaypoints = new List<Transform>();
    [SerializeField]
    private List<Transform> _searchWaypoints = new List<Transform>();
    [SerializeField]
    private int _currentWaypoint;
    [SerializeField]
    private float _searchArea = 20f;
    public string currentList;
    [SerializeField]
    private List<GameObject> listWaypoints;

    public float VisionDetection { get => _visionDetection; set => _visionDetection = value; }
    public float SoundDetection { get => _soundDetection; set => _soundDetection = value; }
    public GameObject Target { get => _target; set => _target = value; }
    public bool Searching { get => _searching; set => _searching = value; }
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public List<Transform> DefaultWaypoints { get => _defaultWaypoints; set => _defaultWaypoints = value; }
    public List<Transform> SearchWaypoints { get => _searchWaypoints; set => _searchWaypoints = value; }
    public int CurrentWaypoint { get => _currentWaypoint; set => _currentWaypoint = value; }
    public float SearchArea { get => _searchArea; set => _searchArea = value; }
    public List<GameObject> ListWaypoints { get => listWaypoints; set => listWaypoints = value; }

    private void OnDrawGizmos()
    {
        float concPlayer = Target.GetComponent<PlayerStats>().ConcealmentValue;
        Gizmos.DrawWireSphere(gameObject.transform.position, concPlayer * _visionDetection);
    }

    public void GoToNextWaypoint(List<Transform> list)
    {
        currentList = "default";
        //select a random waypoint to go
        _currentWaypoint = Random.Range(0, list.Count - 1);
        if(list == _searchWaypoints)
        {
            Debug.Log("tesxtamsdklasmdlkasnlfsal " + _currentWaypoint);
        }
       
        _agent.SetDestination(list[_currentWaypoint].position);
        
    }
    public bool IsAtDestination()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if ((!_agent.hasPath) || (_agent.velocity.sqrMagnitude == 0))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void GoToTarget()
    {
        _agent.SetDestination(_target.transform.position);
    }

    public void StopAgent()
    {
        _agent.isStopped = true;
        _agent.ResetPath();
    }
    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        GoToNextWaypoint(_defaultWaypoints);
    }
}

