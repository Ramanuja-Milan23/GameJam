using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcasterOnTrigger : MonoBehaviour
{
    [SerializeField] private string broadcastMethod;
    [SerializeField] private string broadcastOnTrigger;
    [SerializeField] private GameObject broadcastScope;

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            broadcastScope.BroadcastMessage("getBroadcastTrigger", broadcastOnTrigger);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }
}