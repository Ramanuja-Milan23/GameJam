using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
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
            // get all nearby pickable objects
            var nearbyObjects = Physics2D.OverlapCircleAll(transform.position, radius, 0);

            if (nearbyObjects != null)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    foreach (var nearbyObject in nearbyObjects) { inventory.Add(nearbyObject.name); }
                }
            }
        }
        // throw glassShard in looking direction if E is pressed
        else if(Input.GetKeyDown(KeyCode.E) && inventory.Contains("GlassShard"))
        {
            Vector2 shootDir = GetComponent<Movement>().faceDir;

            RaycastHit2D shoot = Physics2D.Raycast(transform.position, shootDir);

            if (shoot.collider != null)
            {
                shoot.collider.GetComponent<Shootable>().shot();
            }
        }

    }
}
