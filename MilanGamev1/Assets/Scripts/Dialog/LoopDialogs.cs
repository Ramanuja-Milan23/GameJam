using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopDialogs : MonoBehaviour
{
    static int loopCount = 0;

    [SerializeField] private GameObject dialogArea;
    [SerializeField] private Dialogs dialogs;
    [SerializeField] private List<string> dialogIDsLoop2;
    [SerializeField] private List<string> dialogIDsLoop3;
    [SerializeField] private List<string> dialogIDsDefault;

    private List<string> currentLoopDialogs;

    private int currentDialog = 0;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if(loopCount == 1)
        {
            currentLoopDialogs = dialogIDsLoop2;
        }
        else if (loopCount == 2)
        {
            currentLoopDialogs = dialogIDsLoop3;
        }
        else
        {
            currentLoopDialogs = dialogIDsDefault;
        }

        loopCount++;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            dialogArea.SetActive(true);
            isActive = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            if (currentDialog + 1 < currentLoopDialogs.Count)
            {
                currentDialog++;

                if (currentDialog == dialogs.dialogs.Count)
                {
                    isActive = false;
                    dialogArea.SetActive(false);
                }
                else
                {
                    var text = dialogs.dialogs[currentLoopDialogs[currentDialog]];
                    dialogArea.GetComponentInChildren<TMP_Text>().SetText(text);
                }
            }
            else
            {
                isActive = false;
                dialogArea.SetActive(false);
            }
        }
    }
}
