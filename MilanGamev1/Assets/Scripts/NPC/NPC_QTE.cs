using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NPC_QTE : MonoBehaviour
{
    [SerializeField] private GameObject dog;
    [SerializeField] private float timeTillKill = 0f;
    [SerializeField] private GameObject qteSlider;
    [SerializeField] private string lvl_id;

    private List<NPC_Status> npcStatus;

    private float timeAtLevelBegin = 0f;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        var npcs = GetComponentsInChildren<NPC_Status>();

        npcStatus = new List<NPC_Status>();

        foreach (var npc in npcs) { npcStatus.Add(npc); }
    }

    public void getBroadcastTrigger(string levelID)
    {
        // if level 2, then start timer
        if (levelID == lvl_id && !isActive)
        {
            timeAtLevelBegin = Time.realtimeSinceStartup;
            isActive = true;
            qteSlider.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;

        if (Time.realtimeSinceStartup - timeAtLevelBegin > timeTillKill && qteSlider.activeSelf)
        {
            dog.GetComponent<DogKill>().kill();
            qteSlider.SetActive(false);
            isActive = false;
        }

        // if all are dead
        if (npcStatus.All(x => !x.isAlive))
        {
            isActive = false;
            qteSlider.SetActive(false);
            GetComponent<BroadcasterOnTrigger>().trigger();
        }
        else
        {
            qteSlider.GetComponent<Slider>().value = (Time.realtimeSinceStartup - timeAtLevelBegin) / timeTillKill;
        }
    }
}
