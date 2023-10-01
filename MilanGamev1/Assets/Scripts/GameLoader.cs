using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour
{
    bool isActive = false;

    [SerializeField] private GameObject introText;
    [SerializeField] private GameObject image;
    [SerializeField] private Sprite dogLove;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject title;

    bool hasSeenImage = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void load()
    {
        isActive = true;

        button.SetActive(false);
        title.SetActive(false);

        introText.SetActive(true);

        introText.GetComponent<TMP_Text>().SetText("A depressed man walking back from office sees a dog and falls in love with it");

        //SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;

        if (Input.anyKeyDown && !hasSeenImage)
        {
            hasSeenImage = true;

            introText.SetActive(false);

            image.SetActive(true);
            image.GetComponent<Image>().sprite = dogLove;
        }
        else if (Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
        }
    }
}
