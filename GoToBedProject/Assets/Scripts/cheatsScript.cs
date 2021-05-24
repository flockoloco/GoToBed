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
    public GameObject bearPrefab;

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
            Instantiate(bearPrefab, transform.position, Quaternion.identity);
        }
    }
}
