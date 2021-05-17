using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyStats : Stats
{
    [SerializeField]
    private float _visionDetection;
    [SerializeField]
    private float _hearingCapability;
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private bool _searching;
    private NavMeshAgent _agent;
    [SerializeField]
    private List<WayPointInfo> _defaultWaypoints = new List<WayPointInfo>();
    [SerializeField]
    private List<WayPointInfo> _searchWaypoints = new List<WayPointInfo>();
    [SerializeField]
    private int _currentWaypoint;
    [SerializeField]
    private float _searchArea = 20f;
    [SerializeField]
    private List<GameObject> listMainWaypoints;
    public bool heardSomething;
    private FiniteStateMachine _myFsm;
    public TMP_Text currentStatusTextMesh;
    [SerializeField]
    private Animator _animator;



    public float VisionDetection { get => _visionDetection; set => _visionDetection = value; }
    public GameObject Target { get => _target; set => _target = value; }
    public bool Searching { get => _searching; set => _searching = value; }
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public List<WayPointInfo> DefaultWaypoints { get => _defaultWaypoints; set => _defaultWaypoints = value; }
    public List<WayPointInfo> SearchWaypoints { get => _searchWaypoints; set => _searchWaypoints = value; }
    public int CurrentWaypoint { get => _currentWaypoint; set => _currentWaypoint = value; }
    public float SearchArea { get => _searchArea; set => _searchArea = value; }
    public List<GameObject> ListMainWaypoints { get => listMainWaypoints; set => listMainWaypoints = value; }
    public float HearingCapability { get => _hearingCapability; set => _hearingCapability = value; }
    public Animator Animator { get => _animator; set => _animator = value; }

    private void OnDrawGizmos()
    {
        //float concPlayer = Target.GetComponent<PlayerStats>().ConcealmentValue;
        //Gizmos.DrawWireSphere(gameObject.transform.position, concPlayer * _visionDetection);
    }

    public void GoToNextWaypoint(List<WayPointInfo> list)
    {


        if (_currentWaypoint >= (list.Count - 1))
        {
            _currentWaypoint = 0;
        }
        else
        {
            _currentWaypoint++;
        }
        if ( !list.Count.Equals(0))
        {
            _agent.isStopped = false;
            _agent.SetDestination(list[_currentWaypoint].wpPosition);
        }
        else
        {
            _agent.isStopped = true;
        }


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
        _myFsm = GetComponent<FiniteStateMachine>();
        _agent = GetComponent<NavMeshAgent>();
        GoToNextWaypoint(_defaultWaypoints);
        _agent.updateRotation = true;
        
    }
    private void Update()
    {
        StatusTextRotation();

    }

    public void StatusTextRotation()
    {
        currentStatusTextMesh.text = _myFsm.CurrentState.StateDisplayName.ToString();
        currentStatusTextMesh.rectTransform.rotation = Quaternion.LookRotation((gameObject.transform.position - _target.transform.position).normalized, Vector3.up);
    }
}

