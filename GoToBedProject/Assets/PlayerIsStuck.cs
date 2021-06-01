using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsStuck : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            player.GetComponent<PlayerStats>().MoveSpeed = 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            player.GetComponent<PlayerStats>().MoveSpeed = 6;
        }
    }
}
