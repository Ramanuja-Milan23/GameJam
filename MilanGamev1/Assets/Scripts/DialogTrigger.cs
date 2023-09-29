using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogArea;
    [SerializeField] private Dialogs dialogs;
    [SerializeField] private Queue<int> dialogIDs;

    private bool hasSaidDialog = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && !hasSaidDialog)
        {
            foreach(int i in dialogIDs) dialogArea.GetComponentInChildren<TMP_Text>().SetText(dialogs.dialogs[i]);

            hasSaidDialog = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
