using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWebHolder : MonoBehaviour
{
    [System.Serializable]
    public struct WebStruct
    {
        public int type;
        public GameObject webObject;

        public WebStruct(int t, GameObject wo)
        {
            this.type = t; // 0 not instantiated, 1 used, 2 not used
            this.webObject = wo;
        }
    }
    [SerializeField]
    EnemyStats _enemyStats;
    [SerializeField]
    WebStruct[] _webArray = new WebStruct[8];

    void Start()
    {
        for (int i = 0; i < _webArray.Length; i++)
        { 
            if (_webArray[i].type == 0)
            {
                _webArray[i] = new WebStruct(2,Instantiate(_enemyStats.SpiderWeb, new Vector3(1000, 0, 0), Quaternion.Euler(90, 0, 0))); //making sure they are all instantiated
            }
        }
        
    }
    public void MakeNewWeb(out int _numberOfWebs)
    {
        _numberOfWebs = 0;
        bool gotOne = false;
        for (int i = 0; i < _webArray.Length; i++)
        {
            if (_webArray[i].type == 1)
            {
                _numberOfWebs++;
            }
            if (_webArray[i].type == 2 && gotOne == false)
            {
                _webArray[i].webObject.transform.position = _enemyStats.SpiderCoccyx.transform.position;
                _webArray[i].type = 1;
                _numberOfWebs++;
                gotOne = true;
            }
        }
        if (gotOne == false)
        {
            for (int i = 0; i < _webArray.Length; i++)
            {
                if(Vector3.Distance(_enemyStats.Target.transform.position, _webArray[i].webObject.transform.position) > 10)
                {
                    _webArray[i].webObject.transform.position = _enemyStats.SpiderCoccyx.transform.position;
                }
            }
        }
    }
}
