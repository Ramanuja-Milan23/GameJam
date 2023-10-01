using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Story : MonoBehaviour
{
    static int loopCount = 0;
    static int[] dialogueLevels = new int[] {1, 0, 0, 0, 0};

    bool[] hasDialogueSaid = new bool[] { true, false, false, false, false };

    [SerializeField] private GameObject dialogArea;
    [SerializeField] private TMP_Text tutorialText;

    private List<string> dialoguesLoop2;
    private List<string> dialoguesLoop3;

    private List<string> currentLoopDialogs;

    private int currentDialog = 0;
    private bool isActive = false;
    private bool isLvlOne = true;

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
        dialoguesLoop2 = new List<string>
        {
            "Huh?...+Didn't I die?",
            "Oh no! That dog is going to die again!"
        };

        dialoguesLoop3 = new List<string>
        {
            "What?...+Do I loop back here each time I die?",
            "Wait, So I can just kill myself to save it again and again!!"
        };

        if (loopCount == 1)
        {
            currentLoopDialogs = dialoguesLoop2;
        }
        else if (loopCount == 2)
        {
            currentLoopDialogs = dialoguesLoop3;
        }
        else
        {
            currentLoopDialogs = null;
        }

        loopCount++;
    }

    void dialogueOnLevel(string levelID)
    {
        isLvlOne = false;

        // Drunk man level(death)
        if(levelID == "lvl_2" && dialogueLevels[1] == 0 && !hasDialogueSaid[1])
        {
            hasDialogueSaid[1] = true;
            dialogueLevels[1]++;
            isActive = false;

            currentLoopDialogs = new List<string>
            {
                "What is that drunk man doing?...",
                "Nooo, he is killing the dog!!!!"
            };
        }
        // Drunk man level(solution)
        else if (levelID == "lvl_2" && dialogueLevels[1] == 1 && !hasDialogueSaid[1])
        {
            hasDialogueSaid[1] = true;
            dialogueLevels[1]++;
            isActive = false;

            currentLoopDialogs = new List<string>
            {
                "I need to save that dog",
                "I see a glass shard on the floor"
            };
        }
        // VIP level
        else if (levelID == "lvl_3" && dialogueLevels[2] == 0 && !hasDialogueSaid[2])
        {
            hasDialogueSaid[2] = true;
            dialogueLevels[2]++;
            isActive = false;

            currentLoopDialogs = new List<string>
            {
                "Aren't those VIP bodyguards?+What are they doing to <insert dog name>",
                "They deserve to DIE!!"
            };
        }
        // VIP level solve
        else if (levelID == "lvl_3_pass" && dialogueLevels[3] == 0 && !hasDialogueSaid[3])
        {
            hasDialogueSaid[3] = true;
            dialogueLevels[2]++;
            isActive = false;

            currentLoopDialogs = new List<string>
            {
                "I hear police, I think this whole city is corrupted...",
                "We should nuke this city.",
                "It could be possible if I infiltrate the govt buildings.",
                "My <insert dog name> deserves better."
            };
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLoopDialogs == null)
        {
            if (!isActive) { tutorialText.SetText("Use WASD to move"); isActive = true; }
            return;
        }
        if (currentLoopDialogs.Count == 0) return;

        if (!isActive && currentDialog != currentLoopDialogs.Count)
        {
            dialogArea.SetActive(true);
            isActive = true;

            currentDialog = 0;

            var text = currentLoopDialogs[currentDialog];

            dialogArea.GetComponentInChildren<TMP_Text>().SetText(formatString(text));

            Time.timeScale = 0;

            if (loopCount == 2 && isLvlOne)
            {
                tutorialText.SetText("Press Space to continue...");
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (loopCount == 2 && isLvlOne)
            {
                tutorialText.SetText("Save the Dog!");
            }

            if (currentDialog < currentLoopDialogs.Count)
            {
                var text = currentLoopDialogs[currentDialog];

                dialogArea.GetComponentInChildren<TMP_Text>().SetText(formatString(text));

                currentDialog++;
            }
            else
            {
                dialogArea.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
