using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTeddyBearScript : MonoBehaviour
{
    [SerializeField]
    State _animationState;
    [SerializeField]
    float _value = 0;
    [SerializeField]
    bool _finished = false;
    [SerializeField]
    TeddyCanvasScript _teddyCanvas;
    [SerializeField]
    GameObject _player;
    [SerializeField]
    bool _onceBool = false;
    [SerializeField]
    bool _onceBoolTrigger = false;
    [SerializeField]
    bool _startUpdating;


    [SerializeField]
    Vector3 _initialPos;
    [SerializeField]
    Vector3 _initialDir;
    // Start is called before the first frame update
    void Start()
    {
       // _teddyCanvas = GameObject.Find("GrabTeddyInterface").GetComponent<TeddyCanvasScript>();
        //_teddyCanvas.gameObject.SetActive(true);

        
        _player = GameObject.Find("Timmy");

    }

    // Update is called once per frame
    void Update()
    {
        if (_startUpdating) 
        { 
            
            if (_finished && _onceBool == false)
            {
                _teddyCanvas.gameObject.SetActive(false);
                _onceBool = true;
                _player.GetComponent<PlayerStats>().PlayerWon = true;
            }
            else
            {
                if ( _value < 100)
                {
                    _value -= Time.deltaTime * 10;
                    if (_value < 0)
                    {
                        _value = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        _value += 5;
                    }

                }
                if (_value >= 100)
                {
                    _value = 100;
                    _finished = true;
                }
            }
            float finalValue = (((_value / 100 ) * 5 ) - 1);
            Debug.Log(finalValue);
            Debug.Log("initial pos" + _initialPos);
            _player.transform.position = _initialPos - ( _initialDir * finalValue);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if ( _onceBoolTrigger == false)
        {
            if (other.tag == "Player")
            {
                PlayerGrabbedTeddy();
            }
        }
    }
    public void PlayerGrabbedTeddy()
    {
        _player.GetComponent<FiniteStateMachine>().CurrentState = _animationState;
        _player.GetComponent<PlayerStats>().PlayerCamera.CameraState = 3;
        _teddyCanvas.gameObject.SetActive(true);
        _onceBoolTrigger = true;
        _startUpdating = true;
       
        
        Vector3 _bearPosWithY = new Vector3(gameObject.transform.position.x, _player.transform.position.y, gameObject.transform.position.z);


        _initialDir = (_player.transform.position -_bearPosWithY).normalized;
        _initialPos =_player.transform.position - (_player.transform.position - _bearPosWithY -  (_initialDir *  5));
        _player.transform.position = _initialPos;
        gameObject.transform.LookAt(_player.GetComponent<PlayerStats>().PlayerCamera.transform.position);
        _player.GetComponent<PlayerStats>().PlayerCamera.transform.LookAt(gameObject.transform.position);
    }
}
