using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VectorGraphics;

public class PlayerEarChanger : MonoBehaviour
{
    public GameObject player;
    public Sprite firstEar;
    public Sprite middleEar;
    public Sprite secondEar;
    public Sprite thirdEar;
    private SVGImage earImage;
    private void Start()
    {
        earImage = gameObject.GetComponent<SVGImage>();
    }
    private void Update()
    {
       if(player.GetComponent<PlayerStats>().NoiseValue == 0f)
       {
            earImage.sprite = firstEar;
       }
        else if (player.GetComponent<PlayerStats>().NoiseValue < 4f)
        {
            earImage.sprite = firstEar; //change to middle ear
        }
        else if(player.GetComponent<PlayerStats>().NoiseValue >= 4f && player.GetComponent<PlayerStats>().NoiseValue < 8f)
       {
            earImage.sprite = secondEar;
       }
       else if(player.GetComponent<PlayerStats>().NoiseValue >= 8f)
       {
            earImage.sprite = thirdEar;
       }
    }
}
