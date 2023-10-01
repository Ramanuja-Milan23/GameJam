using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableDialog : MonoBehaviour
{
    [SerializeField] private GameObject dialogArea;
    [SerializeField] private Dialogs dialogs;
    [SerializeField] private List<string> dialogIDs;

    private bool hasSaidDialog = false;
    private int currentDialog = 0;
    private bool isActive = false;
    private bool showIfRpressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player" && !hasSaidDialog)
        {
            showIfRpressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        showIfRpressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (showIfRpressed && Input.GetKeyDown(KeyCode.R))
        {
            showIfRpressed = false;

            currentDialog = 0;

            dialogArea.SetActive(true);

            var text = dialogs.dialogs[dialogIDs[currentDialog]];

            dialogArea.GetComponentInChildren<TMP_Text>().SetText(text);

            hasSaidDialog = true;
            isActive = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            if (currentDialog + 1 < dialogIDs.Count)
            {
                currentDialog++;

                if (currentDialog == dialogs.dialogs.Count)
                {
                    isActive = false;
                    dialogArea.SetActive(false);
                }
                else
                {
                    var text = dialogs.dialogs[dialogIDs[currentDialog]];
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
