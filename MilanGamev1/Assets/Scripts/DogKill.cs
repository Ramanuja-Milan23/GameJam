using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogKill : MonoBehaviour
{
    [SerializeField] private List<string> names;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void kill()
    {
        Debug.Log("Killed Dog");

        // disable movement
        transform.GetComponent<PathFollower>().enabled = false;

        // TODO: Do kill animations
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (names.Contains(collision.name))
        {
            kill();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
