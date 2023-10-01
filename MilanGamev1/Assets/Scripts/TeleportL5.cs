using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportL5 : MonoBehaviour
{
    [SerializeField] private GameObject teleportObject;
    [SerializeField] private GameObject aCamera;

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            var cameras = aCamera.GetComponents<CameraL4>();

            if (cameras[0].levelID_active == "lvl_4")
            {
                cameras[0].isActive = false;
                cameras[1].isActive = true;
            }
            else
            {
                cameras[0].isActive = true;
                cameras[1].isActive = false;
            }

            collision.transform.position = teleportObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
