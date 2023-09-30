using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeKill : MonoBehaviour
{
    [SerializeField] private float meleeRange = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, meleeRange);

            if (collider != null)
            {
                Debug.Log(collider.name);

                // kill the guy
                if(collider.isActiveAndEnabled) collider.GetComponent<ShootableLogic>().kill();
            }
        }
    }
}
