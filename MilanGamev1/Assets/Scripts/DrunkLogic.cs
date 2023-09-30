using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkLogic : MonoBehaviour
{
    [SerializeField] private GameObject dog;
    [SerializeField] private float timeBeforeKill = 0f;

    private float timeAtLevelBegin = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void levelBeginBroadcast(int levelID)
    {
        // if level 2, then start timer
        if(levelID == 1)
        {
            timeAtLevelBegin = Time.realtimeSinceStartup;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timeAtLevelBegin - Time.realtimeSinceStartup > timeBeforeKill)
        {
            // kill the dog
            GetComponent<DogKill>().kill();
        }
    }
}
