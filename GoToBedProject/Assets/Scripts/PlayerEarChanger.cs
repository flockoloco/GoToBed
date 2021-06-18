using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VectorGraphics;

public class PlayerEarChanger : MonoBehaviour
{
    public GameObject player;
    public Sprite lowEar;
    public Sprite mediumEar;
    public Sprite highEar;
    public Sprite extraHighEar;
    private SVGImage earImage;
    private void Start()
    {
        earImage = gameObject.GetComponent<SVGImage>();
    }
    private void Update()
    {
        float value = (player.GetComponent<PlayerStats>().NoiseValue - 0) / (10.9f - 0);
        earImage.color = new Color(1, 1, 1, Mathf.Clamp(value,0,1));


    }
}
