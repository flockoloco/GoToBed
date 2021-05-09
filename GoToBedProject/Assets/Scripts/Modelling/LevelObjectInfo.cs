using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectInfo : MonoBehaviour
{
    [HideInInspector]
    public float wallSoundReduction;
    [HideInInspector]
    public float floorSoundIncrement;
    public enum ObjectType
    {
        floor,
        wall
    }
    public ObjectType objectType;
    public enum FloorType
    {
        none,
        quiet,
        normal,
        noisy
    }
    public FloorType floorType;
    public enum Level
    {
        firstLevel,
        secondLevel,
        thirdLevel
    }
    public Level level;
    private void Start()
    {
        if (objectType == ObjectType.floor)
        {
            wallSoundReduction = 0f;
            if (floorType == FloorType.noisy)
                floorSoundIncrement = 0.8f;
            else if (floorType == FloorType.normal)
                floorSoundIncrement = 1.2f;
            else if (floorType == FloorType.noisy)
                floorSoundIncrement = 1.6f;
        }
        else
        {
            wallSoundReduction = 1.5f;
            floorSoundIncrement = 0f;
        }
    }
}
