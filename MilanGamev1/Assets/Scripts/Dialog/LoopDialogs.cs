using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopDialogs : MonoBehaviour
{
    static int loopCount = 0;

    [SerializeField] private GameObject dialogArea;
    [SerializeField] private Dialogs dialogs;
    
    private List<string> dialogIDsLoop2;
    private List<string> dialogIDsLoop3;
    private List<string> dialogIDsDefault;

    private List<string> currentLoopDialogs;

    private int currentDialog = 0;
    private bool isActive = false;

    string formatString(string dialog)
    {
        string final = "";

        foreach (char c in dialog)
        {
            if(c == '+') final += '\n';
            else final += c;
        }

        return final;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogIDsLoop2 = new List<string>
        {
            "Huh?...+Didn't I die?",
        };

        dialogIDsLoop3 = new List<string>
        {
            "What?...+Do I loop each time I die?",
        };

        if (loopCount == 1)
        {
            currentLoopDialogs = dialogIDsLoop2;
        }
        else if (loopCount == 2)
        {
            currentLoopDialogs = dialogIDsLoop3;
        }
        else
        {
            currentLoopDialogs = null;
        }

        loopCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLoopDialogs.Count == 0) return;
        if(currentLoopDialogs == null) return;

        if(!isActive)
        {
            dialogArea.SetActive(true);
            isActive = true;

            currentDialog = 0;

            var text = currentLoopDialogs[currentDialog];

            dialogArea.GetComponentInChildren<TMP_Text>().SetText(formatString(text));

            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogArea.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
