using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameObject dialogArea;
    [SerializeField] private GameObject dog;
    [SerializeField] private string playerPrompt;
    [SerializeField] private string expectedInput;

    private bool isActive = false;
    private string input = string.Empty;
    private bool pressedR = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player" && pressedR)
        {
            isActive = true;

            dialogArea.SetActive(true);

            dialogArea.GetComponentInChildren<TMP_Text>().SetText(playerPrompt);
        }
    }

    // Fixed Update is called once per frame
    void Update()
    {
        pressedR = Input.GetKey(KeyCode.R);

        if (isActive)
        {
            foreach (char c in Input.inputString)
            {
                if(char.IsNumber(c))
                {
                    input += c;
                }
            }

            dialogArea.GetComponentInChildren<TMP_Text>().SetText(playerPrompt + input);

            if (input == expectedInput)
            {
                GetComponent<BroadcasterOnTrigger>().trigger();
                dialogArea.SetActive(false);
                isActive = false;
            }
            else if(input.Length == expectedInput.Length)
            {
                // Call security??

                dog.GetComponent<DogKill>().kill();
            }
        }
    }
}
