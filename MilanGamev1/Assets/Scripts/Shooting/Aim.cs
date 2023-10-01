using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Aim : MonoBehaviour
{
    [SerializeField] private GameObject[] shootablesParent;
    [SerializeField] private Camera cam;

    private Movement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 shootDir = playerMovement.faceDir;

        RaycastHit2D shoot = Physics2D.Raycast(transform.position, shootDir, 100f, ~(1 << 7));

        if(shoot.collider != null) Debug.DrawLine(transform.position, shoot.point, Color.red);

        Debug.DrawRay(transform.position, shootDir, Color.blue);
    }
}
