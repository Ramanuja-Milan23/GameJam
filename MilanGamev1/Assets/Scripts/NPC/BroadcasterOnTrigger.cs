using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcasterOnTrigger : MonoBehaviour
{
    [SerializeField] private string broadcastMethod;
    [SerializeField] private string broadcastOnTrigger;
    [SerializeField] private List<GameObject> broadcastScope;
    [SerializeField] private string colliderName = "Player";

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == colliderName)
        {
            foreach (GameObject go in broadcastScope)
            {
                go.BroadcastMessage(broadcastMethod, broadcastOnTrigger);
            }
        }
    }

    public void trigger()
    {
        foreach (GameObject go in broadcastScope)
        {
            go.BroadcastMessage(broadcastMethod, broadcastOnTrigger);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }
}
