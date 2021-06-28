using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTeddyBearScript : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        _teddyCanvas = GameObject.Find("GrabTeddyInterface").GetComponent<TeddyCanvasScript>();
        _teddyCanvas.gameObject.SetActive(true);

        
        _player = GameObject.Find("Timmy");

    }

    // Update is called once per frame
    void Update()
    {
      
        if (_finished && _onceBool == false)
        {
            _onceBool = true;
            _player.GetComponent<PlayerStats>().PlayerWon = true;
        }
        else
        {
            if (_value > 0 && _value < 100)
            {
                _value -= Time.deltaTime * 10;
                if (Input.GetKeyDown(KeyCode.Space))
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
    }
}
