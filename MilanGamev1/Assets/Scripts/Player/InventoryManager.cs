using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Pickables;
    [SerializeField] private float radius = 0f;
    [SerializeField] private TMP_Text tutorialText;

    public List<string> inventory;
    private bool firstPickup = false;
    private bool isLvl2 = false;

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Shop" && Input.GetKey(KeyCode.R))
        {
            inventory.Add("Gun");
        }
    }

    public void getBroadcastTrigger(string levelID)
    {
        // if level 2, then start timer
        if (levelID == "lvl_2" && !isLvl2)
        {
            firstPickup = true;
            isLvl2 = true;
        }
        else if(levelID == "lvl_2_pass")
        {
            tutorialText.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(firstPickup)
        {
            tutorialText.SetText("Press R to pickup");
        }

        // Add nearby objects to inventory if R is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Pickables != null)
            {
                foreach (var nearbyObject in Pickables)
                {
                    if (Vector2.Distance(nearbyObject.transform.position, transform.position) > radius) continue;

                    if(inventory == null) inventory = new List<string> { nearbyObject.name };
                    else inventory.Add(nearbyObject.name);
                }

                if(firstPickup)
                {
                    tutorialText.SetText("Press E to shoot/throw");
                }

                firstPickup = false;
            }
        }
        // empty inventory
        else if(inventory == null)
        {
            return;
        }
        // throw glassShard in looking direction if E is pressed
        else if(Input.GetKeyDown(KeyCode.E) && inventory.Contains("GlassShard"))
        {
            inventory.Remove("GlassShard");

            Debug.Log("GlassShard");

            Vector2 shootDir = GetComponent<Movement>().faceDir;

            RaycastHit2D shoot = Physics2D.Raycast(transform.position, shootDir);

            if (shoot.collider != null)
            {
                shoot.collider.GetComponent<Shootable>().shot();
            }
        }
        // shoot in looking direction if E is pressed
        else if (Input.GetKeyDown(KeyCode.E) && inventory.Contains("Gun"))
        {
            Vector2 shootDir = GetComponent<Movement>().faceDir;

            Debug.Log("Gun");

            RaycastHit2D shoot = Physics2D.Raycast(transform.position, shootDir);

            if (shoot.collider != null)
            {
                shoot.collider.GetComponent<Shootable>().shot();
            }
        }

    }
}
