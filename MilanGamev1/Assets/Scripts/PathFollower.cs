using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private GameObject pathFollower;
    [SerializeField] private float speed;
    public Animator animator;

    private int currentNode = 0;
    private float timeSinceCurrentNodeStart = 0f;
    private Vector3 lastNodePos;

    public Vector2 faceDir;
    public float thresholdSpeed;

    // Start is called before the first frame update
    void Start()
    {
        faceDir = Vector2.down;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var list = pathFollower.GetComponentsInChildren<PathNode>();
        Vector3 currentPathNode = list[currentNode].transform.position;
        timeSinceCurrentNodeStart += Time.deltaTime;

        if(currentNode == 0)
        {
            transform.position = currentPathNode;
            currentNode++;
            lastNodePos = currentPathNode;

            faceDir = (list[currentNode].transform.position - lastNodePos).normalized;

            return;
        }

        if (transform.position != currentPathNode)
        {
            float dist = Vector3.Distance(lastNodePos, currentPathNode);

            transform.position = Vector3.Lerp(lastNodePos, currentPathNode, timeSinceCurrentNodeStart * speed / dist);
        }
        else
        {
            if(currentNode + 1 < list.Length)
            {
                currentNode++;
            }
            else
            {
                speed = 0f; // temporary FIX HERE, THEEK KR DIO BHAI PLEASE
            }
            lastNodePos = currentPathNode;

            faceDir = (list[currentNode].transform.position - lastNodePos).normalized;
            
            if(faceDir.magnitude < 0.3)
            {
                faceDir = Vector2.down;
            }

            timeSinceCurrentNodeStart = 0f;
        }


        //animator Segment
        animator.SetFloat("Horizontal",faceDir.x*speed);
        animator.SetFloat("Vertical",faceDir.y*speed);
        animator.SetFloat("Speed",speed);
        if (speed > thresholdSpeed){
            animator.SetFloat("prevHorizontal",faceDir.x*speed);
            animator.SetFloat("prevVertical",faceDir.y*speed);
        }


        // Draw the path
        for(int i = 0; i < list.Length - 1; i++)
        {
            Debug.DrawLine(list[i].transform.position, list[i+1].transform.position, Color.red);
        }
    }
}
