using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DogKill : MonoBehaviour
{
    [SerializeField] private List<string> names;

    public bool isDogDead = false;
    public UnityEvent dogDied;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void kill()
    {
        isDogDead = true;

        // disable movement
        transform.GetComponent<PathFollower>().enabled = false;

        // TODO: Do kill animations
        dogDied.Invoke();
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
