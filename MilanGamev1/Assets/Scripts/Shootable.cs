using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // called if the body was shot
    public virtual void shot()
    {
        Debug.LogWarningFormat("Error: Virtual function shot called!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
