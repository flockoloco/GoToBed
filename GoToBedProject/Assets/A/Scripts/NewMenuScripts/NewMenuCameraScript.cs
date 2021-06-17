using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMenuCameraScript : MonoBehaviour
{
    public LevelLoaderScript levelLoader;
    [SerializeField]
    List<Transform> _wayPointList;
    [SerializeField]
    bool _startAnimation = false;
    int _canvasToGoTo = -1;

    public void GoToWayPoint( int _canvasNumber)
    {
        _canvasToGoTo = _canvasNumber;
        _startAnimation = true;
    }

    private void Update()
    {
        if (_startAnimation == true)
        {
            if (_wayPointList[_canvasToGoTo].position != null)
            {
transform.parent.position = Vector3.Lerp(transform.parent.position,_wayPointList[_canvasToGoTo].position,Time.deltaTime * 2);
            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation,_wayPointList[_canvasToGoTo].rotation,Time.deltaTime * 2);
            if ( Vector3.Distance(transform.parent.position, _wayPointList[_canvasToGoTo].position) < 0.01)
            {

                Debug.Log("uh oh");
                _startAnimation = false;
                if (_canvasToGoTo == 3)
                {
                    levelLoader.LoadScene("GoToBed");
                }
                _canvasToGoTo = -1;
                
            }
            }else
            {

            }
            
        }
        
    }

}
