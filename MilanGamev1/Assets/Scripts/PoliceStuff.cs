using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PoliceStuff : ShootableLogic
{
    [SerializeField] private Vector2 faceDir;
    [SerializeField] private float timeTillKill = 0f;
    [SerializeField] private GameObject dog;
    [SerializeField] private GameObject qteSlider;

    public UnityEvent startDeath;

    private float lookRadius = 10f;
    private float timeAtKillBegin = 0f;
    private bool isKilling = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void kill()
    {
        startDeath.Invoke();
        GetComponent<NPC_Status>().isAlive = false;
        qteSlider.SetActive(false);
        isKilling = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D shoot = Physics2D.Raycast(transform.position, faceDir, lookRadius, 1 << 7);

        if(shoot.collider != null)
        {
            if(shoot.collider.name == "Player" && !isKilling)
            {
                timeAtKillBegin = Time.realtimeSinceStartup;
                qteSlider.SetActive(true);
                isKilling = true;
            }
        }

        if(isKilling)
        {
            qteSlider.GetComponent<Slider>().value = (Time.realtimeSinceStartup - timeAtKillBegin) / timeTillKill;
        }

        if(isKilling && Time.realtimeSinceStartup - timeAtKillBegin > timeTillKill && GetComponent<NPC_Status>().isAlive)
        {
            dog.GetComponent<DogKill>().kill();
            qteSlider.SetActive(false);
            isKilling = false;
        }
    }
}
