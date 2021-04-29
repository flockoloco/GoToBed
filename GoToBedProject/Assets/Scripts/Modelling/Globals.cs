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
        Bed
    }
    public enum InteractingObjects
    {
        None,
        Hiding,
        Item
    }
}
