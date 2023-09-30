using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : ShootableLogic
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void kill()
    {
        // TODO: NPC dying animations

        GetComponent<NPC_Status>().isAlive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
