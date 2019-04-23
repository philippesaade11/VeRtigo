using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidTriggerComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "Player")
        {
            Debug.Log("Triggered");
            SceneManager.LoadSceneAsync("Void", LoadSceneMode.Additive);
            GameObject.Find("Scene").SetActive(false);
        }
    }
}
