using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Aim : MonoBehaviour
{
    [SerializeField] private GameObject[] shootablesParent;
    [SerializeField] private Camera cam;
    [SerializeField] private float shootRadius = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ;
        }
    }
}
