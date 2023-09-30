using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shootable : MonoBehaviour
{
    // called if the body was shot
    public virtual void shot()
    {
        Debug.LogWarningFormat("Error: Virtual function shot called!");
    }
}
