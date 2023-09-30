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
    private float actualSpeed;

    private bool isWaitingForTrigger = false;
    private bool isRunning = true;
    private string waitForMessage = "";
    private List<string> receivedMessages;

    // Start is called before the first frame update
    void Start()
    {
        faceDir = Vector2.down;
        receivedMessages = new List<string>();
    }

    public void getBroadcastTrigger(string broadCastMessage)
    {
        if(isWaitingForTrigger)
        {
            if (waitForMessage == broadCastMessage)
            {
                isWaitingForTrigger = false;
                actualSpeed = speed;

                receivedMessages.Add(broadCastMessage);
            }
        }
        else if(!string.IsNullOrEmpty(broadCastMessage))
        {
            receivedMessages.Add(broadCastMessage);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isWaitingForTrigger || !isRunning) return;

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

        if(!string.IsNullOrEmpty(list[currentNode].triggerOnMessage) && !receivedMessages.Contains(list[currentNode].triggerOnMessage))
        {
            isWaitingForTrigger = true;
            waitForMessage = list[currentNode].triggerOnMessage;
            actualSpeed = 0f;
        }

        if (transform.position != currentPathNode)
        {
            actualSpeed = speed;

            float dist = Vector3.Distance(lastNodePos, currentPathNode);

            transform.position = Vector3.Lerp(lastNodePos, currentPathNode, timeSinceCurrentNodeStart * actualSpeed / dist);
        }
        else
        {
            if (currentNode + 1 < list.Length)
            {
                // if it was broadcast then pause
                if (!string.IsNullOrEmpty(list[currentNode].pauseOnMessage) && receivedMessages.Contains(list[currentNode].pauseOnMessage))
                {
                    isRunning = false;
                    actualSpeed = 0f;
                }
                else
                {
                    currentNode++;
                }
            }
            else
            {
                actualSpeed = 0f;
            }
            lastNodePos = currentPathNode;

            faceDir = (list[currentNode].transform.position - lastNodePos).normalized;

            if (faceDir.magnitude < 0.3)
            {
                faceDir = Vector2.down;
            }

            timeSinceCurrentNodeStart = 0f;
        }


        //animator Segment
        animator.SetFloat("Horizontal", faceDir.x * actualSpeed);
        animator.SetFloat("Vertical", faceDir.y * actualSpeed);
        animator.SetFloat("Speed", actualSpeed);
        
        if (speed > thresholdSpeed)
        {
            animator.SetFloat("prevHorizontal", faceDir.x * actualSpeed);
            animator.SetFloat("prevVertical", faceDir.y * actualSpeed);
        }

        // Draw the path
        for(int i = 0; i < list.Length - 1; i++)
        {
            Debug.DrawLine(list[i].transform.position, list[i+1].transform.position, Color.red);
        }
    }
}
