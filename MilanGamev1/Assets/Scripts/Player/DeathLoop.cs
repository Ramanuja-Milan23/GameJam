using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLoop : MonoBehaviour
{
    [SerializeField] private DogKill dogKilled;

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    // returns true if animation finished
    bool killAnimation()
    {
        // TODO: show suicide animations
        FindObjectOfType<AudioManager>().Play("PlayerGlitch");

        return true;
    }

    // Update is called once per frame
    void Update()
    {
        // only runs if dog was killed
        if (!dogKilled.isDogDead) return;

        if(killAnimation())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
