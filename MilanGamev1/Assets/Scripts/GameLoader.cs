using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void load()
    {
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
