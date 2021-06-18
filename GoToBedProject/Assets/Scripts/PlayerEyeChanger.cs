using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VectorGraphics;

public class PlayerEyeChanger : MonoBehaviour
{
    public GameObject player;
    private SVGImage eyeImage;
    private PlayerStats playerStats;

    private void Start()
    {
        eyeImage = gameObject.GetComponent<SVGImage>();
        playerStats = player.GetComponent<PlayerStats>();
    }
    private void Update()
    {
         float value = (playerStats.ConcealmentValue - 0.006f) / (16f - 0.006f) ;
        //Debug.Log(playerStats.ConcealmentValue);
        eyeImage.color = new Color(1, 1, 1, Mathf.Clamp(value ,0,1));


    }
}
