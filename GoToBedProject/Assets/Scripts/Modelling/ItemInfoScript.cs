using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoScript : ItemObjectiveObjectInfoBase
{

    public void ChangeCollidableLayer(int layer)
    {
        CollidableChild.layer = layer;
    }
}
