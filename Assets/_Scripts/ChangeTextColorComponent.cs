using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTextColorComponent : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }
    
    public void OnSelect(BaseEventData eventData)
    {
        text.color = new Color(0, 0, 0);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        text.color = new Color(255, 255, 255);
    }
}
