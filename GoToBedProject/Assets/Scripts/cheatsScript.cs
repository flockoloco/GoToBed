using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatsScript : MonoBehaviour
{
    [SerializeField]
    public GameObject scissorsPrefab;
    [SerializeField]
    public GameObject keyPrefab;
    [SerializeField]
    public GameObject flashLightPrefab;
    [SerializeField]
    public GameObject batteriesPrefab;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(scissorsPrefab, transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            Instantiate(keyPrefab, transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(flashLightPrefab, transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(batteriesPrefab, transform.position, Quaternion.identity);
        }
    }
}
