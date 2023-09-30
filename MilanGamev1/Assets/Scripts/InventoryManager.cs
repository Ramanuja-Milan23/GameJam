using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Pickables;
    [SerializeField] private float radius = 0f;

    private List<string> inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Add nearby objects to inventory if R is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Pickables != null)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    foreach (var nearbyObject in Pickables)
                    {
                        if (Vector2.Distance(nearbyObject.transform.position, transform.position) > radius) continue;

                        Debug.Log("Picked Up " + nearbyObject.name);

                        if(inventory == null) inventory = new List<string> { nearbyObject.name };
                        else inventory.Add(nearbyObject.name);
                    }
                }
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

            Debug.Log("Hit " + shoot.collider.name);

            if (shoot.collider != null)
            {
                shoot.collider.GetComponent<Shootable>().shot();
            }
        }

    }
}
