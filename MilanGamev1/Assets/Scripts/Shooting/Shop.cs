using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!inventoryManager.inventory.Contains("Gun") && Input.GetKey(KeyCode.R)) inventoryManager.inventory.Add("Gun");
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }
}
