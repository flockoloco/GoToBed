using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WayPointInfo : MonoBehaviour
{
    public WayPointInfo(int t, Vector3 p)
    {
        this.type = t;
        this.wpPosition = p;
    }

    [SerializeField]
    public int type; //0 look around, 1 closet look inside, 2 table look under, 3 bed look under etc
    [SerializeField]
    public Vector3 wpPosition;


    private void Start()
    {
        wpPosition = gameObject.transform.position;
    }

}
