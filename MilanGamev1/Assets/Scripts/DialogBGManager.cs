using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBGManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform thisTransform = transform.GetComponent<RectTransform>();

        thisTransform.sizeDelta = text.textBounds.size;
    }
}
