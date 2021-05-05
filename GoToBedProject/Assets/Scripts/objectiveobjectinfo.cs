using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectiveobjectinfo : ItemObjectiveObjectInfoBase
{
    [SerializeField]
    private Globals.GameTags _usableTag;
    [SerializeField]
    private string _wrongItemText;
    [SerializeField]
    private string _correctItemText;


    public Globals.GameTags UsableTag { get => _usableTag; set => _usableTag = value; }
    public string WrongItemText { get => _wrongItemText; set => _wrongItemText = value; }
    public string CorrectItemText { get => _correctItemText; set => _correctItemText = value; }

    public void ObjectiveInteraction(PlayerStats playerStats)
    {
        if(gameObject.CompareTag(Globals.GameTags.Web.ToString()))
        {

            Destroy(playerStats.EquippedItem);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag(Globals.GameTags.Ladder.ToString()))
        {
            Destroy(playerStats.EquippedItem);
            //rotate
        }
    }


}
