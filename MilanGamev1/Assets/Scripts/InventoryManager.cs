using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Pickables;
    [SerializeField] private float radius = 0f;
    [SerializeField] private TMP_Text tutorialText;

    private List<string> inventory;
    private bool firstPickup = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(firstPickup)
        {
            tutorialText.SetText("Press R to pickup items");
        }

        // Add nearby objects to inventory if R is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Pickables != null)
            {
                foreach (var nearbyObject in Pickables)
                {
                    if (Vector2.Distance(nearbyObject.transform.position, transform.position) > radius) continue;

                    Debug.Log("Picked Up " + nearbyObject.name);

                    if(inventory == null) inventory = new List<string> { nearbyObject.name };
                    else inventory.Add(nearbyObject.name);
                }

                if(firstPickup)
                {
                    tutorialText.SetText("Press E to use item");
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
            Vector2 shootDir = GetComponent<Movement>().faceDir;

            RaycastHit2D shoot = Physics2D.Raycast(transform.position, shootDir);

            // DEBUG
            Debug.Log("Hit " + shoot.collider.name);

            if (shoot.collider != null)
            {
                shoot.collider.GetComponent<Shootable>().shot();
            }
        }

    }
}
