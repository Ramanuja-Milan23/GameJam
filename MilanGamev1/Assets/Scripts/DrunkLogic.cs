using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkLogic : MonoBehaviour
{
    [SerializeField] private GameObject dog;
    [SerializeField] private float timeBeforeKill = 0f;

    private float timeAtLevelBegin = 0f;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void levelBeginBroadcast(string levelID)
    {
        // if level 2, then start timer
        if(levelID == "lvl_2" && !isActive)
        {
            timeAtLevelBegin = Time.realtimeSinceStartup;
            isActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup - timeAtLevelBegin > timeBeforeKill && isActive)
        {
            // kill the dog
            dog.GetComponent<DogKill>().kill();

            isActive = false;
        }
    }
}
