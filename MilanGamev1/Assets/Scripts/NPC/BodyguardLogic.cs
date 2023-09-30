using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyguardLogic : ShootableLogic
{
    [SerializeField] private GameObject dog;
    [SerializeField] private float timeTillKill = 0f;
    [SerializeField] private float timeTillKillAnimationStart = 0f;
    [SerializeField] private bool willKillDog = false;
    [SerializeField] private GameObject qteSlider;

    private float timeAtLevelBegin = 0f;
    private bool isActive = false;
    private bool isAnimating = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void getBroadcastTrigger(string levelID)
    {
        // if level 2, then start timer
        if (levelID == "lvl_3" && !isActive)
        {
            timeAtLevelBegin = Time.realtimeSinceStartup;
            isActive = true;
            if (willKillDog) qteSlider.SetActive(true);
        }
    }

    public override void kill()
    {
        // TODO: start kill animation?

        isActive = false;
        isAnimating = true;
        if (willKillDog) qteSlider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive && !isAnimating) return;

        if (isAnimating)
        {
            // TODO: do dying animation

            return;
        }

        if(willKillDog) qteSlider.GetComponent<Slider>().value = (Time.realtimeSinceStartup - timeAtLevelBegin) / timeTillKill;

        if (Time.realtimeSinceStartup - timeAtLevelBegin > timeTillKillAnimationStart && willKillDog)
        {
            float timeSinceAnimationStart = Time.realtimeSinceStartup - timeAtLevelBegin;

            // TODO: do gun shoot animation
        }

        if (Time.realtimeSinceStartup - timeAtLevelBegin > timeTillKill && willKillDog)
        {
            // kill the dog
            dog.GetComponent<DogKill>().kill();

            isActive = false;
            if (willKillDog) qteSlider.SetActive(false);
        }
    }
}