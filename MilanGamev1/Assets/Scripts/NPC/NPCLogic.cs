using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCLogic : ShootableLogic
{
    public Animator animator;

    public UnityEvent startDeath;

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    public override void kill()
    {
        // TODO: NPC dying animations
        startDeath.Invoke();

        GetComponent<NPC_Status>().isAlive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
