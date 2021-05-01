using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float VisionDetection { get => _visionDetection; set => _visionDetection = value; }
    public float SoundDetection { get => _soundDetection; set => _soundDetection = value; }
    public GameObject Target { get => _target; set => _target = value; }
    public bool Searching { get => _searching; set => _searching = value; }

    private void OnDrawGizmos()
    {
        float concPlayer = Target.GetComponent<PlayerStats>().ConcealmentValue;
        Gizmos.DrawWireSphere(gameObject.transform.position, concPlayer * _visionDetection);
    }
}

