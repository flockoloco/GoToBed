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
    [SerializeField]
    private Globals.Enemy _enemyName;
    [SerializeField]
    private Transform _eyesPosition;
    [SerializeField]
    private WayPointInfo _playerWayPoint;
    [SerializeField]
    private GameObject _spiderCoccyx;
    [SerializeField]
    private GameObject _spiderWeb;

    // new shit for the door animation
    public State OldState;
    public List<WayPointInfo> OldSearchList = new List<WayPointInfo>();
    public int OldCurrentWaypoint;
    public DoorScript OldDoorScript;

    //sound
    public AudioClip _footStep;
    public AudioClip _runningFootStep;
    private AudioSource _audioSource;


    //end of new shit



    public float VisionDetection { get => _visionDetection; set => _visionDetection = value; }
    public GameObject Target { get => _target; set => _target = value; }
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public List<WayPointInfo> DefaultWaypoints { get => _defaultWaypoints; set => _defaultWaypoints = value; }
    public List<WayPointInfo> SearchWaypoints { get => _searchWaypoints; set => _searchWaypoints = value; }
    public int CurrentWaypoint { get => _currentWaypoint; set => _currentWaypoint = value; }
    public float SearchArea { get => _searchArea; set => _searchArea = value; }
    public List<GameObject> ListMainWaypoints { get => listMainWaypoints; set => listMainWaypoints = value; }
    public float HearingCapability { get => _hearingCapability; set => _hearingCapability = value; }
    public Animator Animator { get => _animator; set => _animator = value; }
    public WayPointInfo PlayerWayPoint { get => _playerWayPoint; set => _playerWayPoint = value; }
    public Globals.Enemy EnemyName { get => _enemyName; set => _enemyName = value; }
    public Transform EyesPosition { get => _eyesPosition; set => _eyesPosition = value; }
    public GameObject SpiderCoccyx { get => _spiderCoccyx; set => _spiderCoccyx = value; }
    public GameObject SpiderWeb { get => _spiderWeb; set => _spiderWeb = value; }

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
        _audioSource = GetComponent<AudioSource>();
        _myFsm = GetComponent<FiniteStateMachine>();
        _agent = GetComponent<NavMeshAgent>();
        TurnOffThenTurnOnAnimation("Walking");
        if (_myFsm.dontTriggerStart == false  )
        {
            GoToNextWaypoint(_defaultWaypoints);
        }
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
    public void TurnOffThenTurnOnAnimation(string boolName)
    {
        //me recuso a dar false um por um
        foreach(AnimatorControllerParameter parameter in _animator.parameters)
        {
            _animator.SetBool(parameter.name, false);
        }
        Animator.SetBool(boolName, true);
    }
    //not being used, maybe in the future
    public void StateAnimation(string stateName, int stateNumber)
    {
        Animator.SetInteger(stateName, stateNumber);
    }

    public void playWalkFootStep()
    {
        _audioSource.PlayOneShot(_footStep);
    }
    public void playRunningFootStep()
    {
        _audioSource.PlayOneShot(_runningFootStep);
    }

}

