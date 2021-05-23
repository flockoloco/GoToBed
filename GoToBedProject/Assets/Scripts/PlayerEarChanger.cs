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
       if(player.GetComponent<PlayerStats>().NoiseValue == 0f)
       {
            earImage.sprite = lowEar;
       }
        else if (player.GetComponent<PlayerStats>().NoiseValue < 4f)
        {
            earImage.sprite = mediumEar; //change to middle ear
        }
        else if(player.GetComponent<PlayerStats>().NoiseValue >= 4f && player.GetComponent<PlayerStats>().NoiseValue < 8f)
       {
            earImage.sprite = highEar;
       }
       else if(player.GetComponent<PlayerStats>().NoiseValue >= 8f)
       {
            earImage.sprite = extraHighEar;
       }
    }
}
