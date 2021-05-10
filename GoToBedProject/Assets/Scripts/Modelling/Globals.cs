using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    //to decide which one we use
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
        Key
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

}
