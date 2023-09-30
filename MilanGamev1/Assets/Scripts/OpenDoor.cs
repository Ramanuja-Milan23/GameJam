using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject trigger;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void getBroadcastTrigger(string levelID)
    {
        // if level 2, then start timer
        if (levelID == "lvl_4_pass")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            trigger.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}