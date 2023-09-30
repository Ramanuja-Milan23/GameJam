using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcasterOnTrigger : MonoBehaviour
{
    [SerializeField] private string broadcastMethod;
    [SerializeField] private string broadcastOnTrigger;
    [SerializeField] private List<GameObject> broadcastScope;
    [SerializeField] private string colliderName = "Player";
    [SerializeField] private bool isScriptOnly = false;

    private bool hasBroadcasted = false;

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasBroadcasted) return;
        if (string.IsNullOrEmpty(broadcastMethod)) return;
        if (isScriptOnly) return;

        if (collision.name == colliderName)
        {
            foreach (GameObject go in broadcastScope)
            {
                go.BroadcastMessage(broadcastMethod, broadcastOnTrigger);
            }

            hasBroadcasted = true;
        }
    }

    public void trigger()
    {
        if (hasBroadcasted) return;
        if (string.IsNullOrEmpty(broadcastMethod)) return;

        foreach (GameObject go in broadcastScope)
        {
            go.BroadcastMessage(broadcastMethod, broadcastOnTrigger);
        }

        hasBroadcasted = true;
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }
}
