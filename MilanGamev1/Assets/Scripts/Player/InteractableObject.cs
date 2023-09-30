using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name + ": " + Input.GetKey(KeyCode.R));

        if (collision.name == "Player" && Input.GetKey(KeyCode.R))
        {
            GetComponent<DialogTrigger>().startDialog();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }
}
