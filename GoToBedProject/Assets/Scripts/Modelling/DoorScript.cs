using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorScript : objectiveobjectinfo
{
    [SerializeField]
    private bool _locked;
    [SerializeField]
    private bool _open;
    [SerializeField]
    private Animator _animator;
    string _openString = "Open";
    [SerializeField]
    private string _unlockText = "Unlock!";
    private string _closeText = "Close!";
    [SerializeField]
    private NavMeshObstacle _obstacleComponent;
    [SerializeField]
    private AudioSource _doorAudio;
    [SerializeField]
    private AudioClip _doorSoundClip;

    public bool Locked { get => _locked; set => _locked = value; }
    public string UnlockText { get => _unlockText; set => _unlockText = value; }
    public string CloseText { get => _closeText; set => _closeText = value; }
    public bool Open { get => _open; set => _open = value; }

    public void DoorInteraction(PlayerStats playerStats)
    {
        _doorAudio.PlayOneShot(_doorSoundClip);
        playerStats.InteractionCoolDown = 0;
        if (Locked)
        {
            Locked = false;

            Destroy(playerStats.EquippedItem);
            _animator.SetBool(_openString, true);
            Open = true;
            _obstacleComponent.enabled = true;

        }
        else if (Open)
        {
            _animator.SetBool(_openString,false);
            Open = false;
            _obstacleComponent.enabled = false;
        }
        else if (!Open)
        {
            _animator.SetBool(_openString, true);
            Open = true;
            _obstacleComponent.enabled = true;
        }

    }
    public void DoorInteraction(EnemyStats enemyStats)
    {
        _doorAudio.PlayOneShot(_doorSoundClip);
        if (!Open)
        {
            _animator.SetBool(_openString, true);
            Open = true;
            _obstacleComponent.enabled = true;
        }
    }

}
