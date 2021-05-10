using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : objectiveobjectinfo
{
    [SerializeField]
    private bool _locked;
    [SerializeField]
    private bool _open;
    [SerializeField]
    private Animator _animator;
    string _openString = "Open";

    public bool Locked { get => _locked; set => _locked = value; }

    public void DoorInteraction(PlayerStats playerStats)
    {
        playerStats.InteractionCoolDown = 0;
        if (Locked)
        {
            Locked = false;
            
            Destroy(playerStats.EquippedItem);
            _animator.SetBool(_openString, true);
            _open = true;

        }
        if (_open)
        {
            _animator.SetBool(_openString,false);
            _open = false;
        }
        else if (!_open)
        {
            _animator.SetBool(_openString, true);
            _open = true;
        }

    }
}
