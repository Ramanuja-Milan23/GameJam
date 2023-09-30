using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableLogic : MonoBehaviour
{
    public virtual void kill()
    {
        Debug.LogWarningFormat("ERROR: Called a virtual function");
    }
}
