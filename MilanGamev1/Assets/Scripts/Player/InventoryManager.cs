using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Pickables;
    [SerializeField] private float radius = 3f;
    [SerializeField] private float shootRadius = 50f;
    [SerializeField] private TMP_Text tutorialText;

    public Animator animator;

    public List<string> inventory;
    private bool firstPickup = false;
    private bool isLvl2 = false;
    private bool pickupGunsOnRpress = false;

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    private void OnTriggerEntry2D(Collider2D collision)
    {
        if (collision.name == "Shop") pickupGunsOnRpress = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pickupGunsOnRpress = false;
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

        if (pickupGunsOnRpress && Input.GetKeyDown(KeyCode.R))
        {
            inventory.Add("Gun");
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

            Vector2 shootDir = GetComponent<Movement>().faceDir;

            RaycastHit2D shoot = Physics2D.Raycast(transform.position, shootDir, shootRadius, ~(1 << 7));

            if (shoot.collider != null)
            {
                shoot.collider.GetComponent<Shootable>().shot();
            }
        }
        // shoot in looking direction if E is pressed
        else if (Input.GetKeyDown(KeyCode.E) && inventory.Contains("Gun"))
        {
            Vector2 shootDir = GetComponent<Movement>().faceDir;

            RaycastHit2D shoot = Physics2D.Raycast(transform.position, shootDir, shootRadius, ~(1 << 7));
            
            if (shoot.collider != null)
            {
                if (shoot.collider.GetComponent<Shootable>() != null) shoot.collider.GetComponent<Shootable>().shot();
                else if (shoot.collider.GetComponent<ShootableLogic>() != null) shoot.collider.GetComponent<ShootableLogic>().kill();
            }
        }
        if (inventory.Contains("Gun")){
            animator.SetBool("HasGun",true);
        }
    }
}
