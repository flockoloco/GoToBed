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
        _timer += Time.deltaTime * 5;
        float result = Mathf.Sin(_timer);
        interactImage.transform.localScale = new Vector3(result,result,result);
    }
}
