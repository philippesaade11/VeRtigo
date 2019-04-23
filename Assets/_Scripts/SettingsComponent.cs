using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SettingsComponent : MonoBehaviour
{
    public Button snap_btn, map_btn, savequite_btn;
    // Start is called before the first frame update
    void Start()
    {
        map_btn.onClick.AddListener(gotomap);
    }

    void OnEnable()
    {
        snap_btn.Select();
        foreach (Transform child in transform)
        {
            if(child.gameObject.name != "Pause")
            {
                child.gameObject.SetActive(false);
            } else
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void gotomap()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name != "Map")
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
