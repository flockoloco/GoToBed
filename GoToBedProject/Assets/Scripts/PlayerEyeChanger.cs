using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VectorGraphics;

public class PlayerEyeChanger : MonoBehaviour
{
    public GameObject player;
    public Sprite openedEye;
    public Sprite middleOpenedEye;
    public Sprite closedEye;
    private SVGImage eyeImage;

    private void Start()
    {
        eyeImage = gameObject.GetComponent<SVGImage>();
    }
    private void Update()
    {
       if(player.GetComponent<PlayerStats>().ConcealmentValue < 1f)
       {
            eyeImage.sprite = closedEye;
       }
       else if(player.GetComponent<PlayerStats>().ConcealmentValue >= 1f && player.GetComponent<PlayerStats>().ConcealmentValue < 1.5f)
       {
            eyeImage.sprite = middleOpenedEye;
       }
       else if(player.GetComponent<PlayerStats>().ConcealmentValue >= 1.5)
       {
            eyeImage.sprite = openedEye;
       }
    }
}
