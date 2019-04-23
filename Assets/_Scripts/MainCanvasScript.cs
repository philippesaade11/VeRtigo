using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainCanvasScript : MonoBehaviour
{
    public Button cont_btn, newadv_btn, settings_btn, exit_btn, adjVR_btn, adjDif_btn, bck_btn;
    public float speed;
    public Camera cam1, cam2;

    // Start is called before the first frame update
    void Start()
    {
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);
        settings_btn.onClick.AddListener(gotosettings);
        bck_btn.onClick.AddListener(gotomain);
        newadv_btn.onClick.AddListener(map);
        cont_btn.Select();
    }

    void gotosettings()
    {
        cam2.gameObject.SetActive(true);
        cam1.gameObject.SetActive(false);
        adjVR_btn.Select();
    }
    void gotomain()
    {
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);
        cont_btn.Select();
    }
    void map()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void select()
    {
        Debug.Log(this.gameObject.name + " was selected");
    }
}
