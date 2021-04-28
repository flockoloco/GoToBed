using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCheckScript : MonoBehaviour
{
    public PlayerStats playerStats;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light")
        {
            playerStats.LightsInRange.Add(other.gameObject);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Light")
        {
            playerStats.LightsInRange.Remove(other.gameObject);
        }
    }
}
