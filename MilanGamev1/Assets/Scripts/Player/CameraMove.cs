using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject cameraPositions;
    [SerializeField] private Camera mainCam;
    [SerializeField] private Vector2 faceDirOnEnter;
    [SerializeField] private int prev = 0;
    [SerializeField] private int next = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            var list = cameraPositions.GetComponentsInChildren<PathNode>();

            Vector2 faceDir = collision.GetComponent<Movement>().faceDir;

            if(Vector2.Dot(faceDir, faceDirOnEnter) > 0f)
            {
                Vector2 newPos = list[next].transform.position;
                mainCam.transform.position = new Vector3(newPos.x, newPos.y, -1.0f);
            }
            else
            {
                Vector2 newPos = list[prev].transform.position;
                mainCam.transform.position = new Vector3(newPos.x, newPos.y, -1.0f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            var list = cameraPositions.GetComponentsInChildren<PathNode>();

            Vector2 faceDir = collision.GetComponent<Movement>().faceDir;

            if (Vector2.Dot(faceDir, faceDirOnEnter) > 0f)
            {
                Vector2 newPos = list[next].transform.position;
                mainCam.transform.position = new Vector3(newPos.x, newPos.y, -1.0f);
            }
            else
            {
                Vector2 newPos = list[prev].transform.position;
                mainCam.transform.position = new Vector3(newPos.x, newPos.y, -1.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
