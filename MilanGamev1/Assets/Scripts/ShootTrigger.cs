using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrigger : Shootable
{
    [SerializeField] private string broadcastMethod;
    [SerializeField] private string broadcastOnTrigger;
    [SerializeField] private GameObject broadcastScope;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void shot()
    {
        broadcastScope.BroadcastMessage("getBroadcastTrigger", broadcastOnTrigger);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
