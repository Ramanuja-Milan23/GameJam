using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameObject dialogArea;
    [SerializeField] private string playerPrompt;
    [SerializeField] private string expectedInput;

    private bool hasSaidDialog = false;
    private bool isActive = false;
    private string input = string.Empty;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && !hasSaidDialog)
        {
            isActive = true;

            dialogArea.SetActive(true);

            dialogArea.GetComponentInChildren<TMP_Text>().SetText(playerPrompt);
        }
    }

    // Fixed Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            foreach (char c in Input.inputString)
            {
                if(char.IsNumber(c))
                {
                    input += c;
                }
            }

            if (input == playerPrompt)
            {
                GetComponent<BroadcasterOnTrigger>().trigger();
            }
        }
    }
}
