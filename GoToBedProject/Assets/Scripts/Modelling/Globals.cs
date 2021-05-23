using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class Globals
{
    public enum Enemy
    {
        Spider,
        Clown,
        CrookedMan
    }
    public enum GameTags
    {
        Untagged, 
        Respawn, 
        Finish, 
        EditorOnly, 
        MainCamera, 
        Player, 
        GameController, 
        Interactable, 
        Light, 
        Closet, 
        HidingObject, 
        Lantern,
        Waypoint,
        Bed,
        Table,
        Scissors,
        Web,
        Ladder,
        Rope,
        Door,
        Key,
        DarkZone,
        TeddyBear
    }
    public enum InteractingObjects
    {
        None,
        Hiding,
        Item,
        Objective,
        Door
    }
    public enum typeOfHiding //move this out of here, put in modelling
    {
        Closet,
        Bed,
        Table
        //....
    }
    public enum Menus
    {
        Death,
        Win,
        Pause
    }
}
