using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemiesStats : Stats
{
    private float _visionDetection;
    private float _soundDetection;
    private GameObject _target;
    public float VisionDetection { get => _visionDetection; set => _visionDetection = value; }
    public float SoundDetection { get => _soundDetection; set => _soundDetection = value; }
    public GameObject Target { get => _target; set => _target = value; }
}

