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
    [SerializeField]
    private string _unlockText = "Unlock!";
    private string _closeText = "Close!";

    public bool Locked { get => _locked; set => _locked = value; }
    public string UnlockText { get => _unlockText; set => _unlockText = value; }
    public string CloseText { get => _closeText; set => _closeText = value; }
    public bool Open { get => _open; set => _open = value; }

    public void DoorInteraction(PlayerStats playerStats)
    {
        playerStats.InteractionCoolDown = 0;
        if (Locked)
        {
            Locked = false;

            Destroy(playerStats.EquippedItem);
            _animator.SetBool(_openString, true);
            Open = true;

        }
        else if (Open)
        {
            _animator.SetBool(_openString,false);
            Open = false;
        }
        else if (!Open)
        {
            _animator.SetBool(_openString, true);
            Open = true;
        }

    }
    public void DoorInteraction(EnemyStats enemyStats)
    {
        
        if (!Open)
        {
            _animator.SetBool(_openString, true);
            Open = true;
        }
        

    }
}
