using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_L4 : MonoBehaviour
{
    [SerializeField] private GameObject dog;
    [SerializeField] private float timeTillKill = 0f;
    [SerializeField] private GameObject qteSlider;

    private float timeAtLevelBegin = 0f;
    private bool isActive = false;

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
            qteSlider.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - timeAtLevelBegin > timeTillKill && qteSlider.activeSelf)
        {
            qteSlider.SetActive(false);
        }

        if (!(GetComponentsInChildren<BodyguardLogic>()[0].isActive || GetComponentsInChildren<BodyguardLogic>()[1].isActive) && qteSlider.activeSelf)
        {
            qteSlider.SetActive(false);
        }

        if (!(GetComponentsInChildren<BodyguardLogic>()[0].isActive || GetComponentsInChildren<BodyguardLogic>()[1].isActive)) return;

        qteSlider.GetComponent<Slider>().value = (Time.realtimeSinceStartup - timeAtLevelBegin) / timeTillKill;
    }
}
