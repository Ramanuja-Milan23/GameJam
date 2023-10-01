using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    bool isActive = false;

    [SerializeField] private TMP_Text introText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void load()
    {
        isActive = true;

        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            ;
        }
    }
}
