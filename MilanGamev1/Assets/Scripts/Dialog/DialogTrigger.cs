using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogArea;
    [SerializeField] private Dialogs dialogs;
    [SerializeField] private List<string> dialogIDs;
    [SerializeField] public bool isTriggeredDialog = true;

    private bool hasSaidDialog = false;
    private int currentDialog = 0;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && !hasSaidDialog && isTriggeredDialog)
        {
            currentDialog = 0;

            dialogArea.SetActive(true);

            var text = dialogs.dialogs[dialogIDs[currentDialog]];

            dialogArea.GetComponentInChildren<TMP_Text>().SetText(text);

            hasSaidDialog = true;
            isActive = true;
        }
    }

    public void startDialog()
    {
        currentDialog = 0;

        dialogArea.SetActive(true);

        var text = dialogs.dialogs[dialogIDs[currentDialog]];

        dialogArea.GetComponentInChildren<TMP_Text>().SetText(text);

        hasSaidDialog = true;
        isActive = true;
    }

    // Fixed Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isActive)
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
