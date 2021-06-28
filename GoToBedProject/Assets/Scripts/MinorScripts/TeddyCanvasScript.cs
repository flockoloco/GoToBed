using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeddyCanvasScript : MonoBehaviour
{
    public GameObject interactImage;
    [SerializeField]
    private float _timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if ( _timer < 1)
        {
            _timer += Time.deltaTime * 15;
            if ( _timer > 1)
            {
                _timer = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _timer = 0;
        }
        
        
        float result =  2 * Mathf.Sin(_timer);

        if ( result < 0)
        {
            result *= -1;
        }
        result = Mathf.Clamp(result, 0.9f, 2f);

        interactImage.transform.localScale = new Vector3(result,result,result);
    }
}
