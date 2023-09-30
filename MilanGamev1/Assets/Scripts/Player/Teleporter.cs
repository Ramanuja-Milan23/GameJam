using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject teleportObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player") collision.transform.position = teleportObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
