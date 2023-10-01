using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraL4 : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float x_clamp_left = 0f;
    [SerializeField] private float x_clamp_right = 0f;
    [SerializeField] public string levelID_active;
    [SerializeField] private string levelID_deactive;

    [SerializeField] public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void getBroadcastTrigger(string levelID)
    {
        // if level 2, then start timer
        if (levelID == levelID_active && !isActive)
        {
            isActive = true;
        }
        else if (levelID == levelID_deactive && isActive)
        {
            isActive = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isActive) transform.position = new Vector3(Mathf.Clamp(playerTransform.position.x, x_clamp_left, x_clamp_right), transform.position.y, transform.position.z);
    }
}
