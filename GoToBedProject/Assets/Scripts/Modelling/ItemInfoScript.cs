using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoScript : ItemObjectiveObjectInfoBase
{

    public void SetLayerRecursively( GameObject obj, int layer)
    {
        obj.layer = layer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject,layer);
        }
    }



    public void ChangeCollidableLayer(int layer)
    {
        CollidableChild.layer = layer;
        SetLayerRecursively(gameObject,4);
    }
}
