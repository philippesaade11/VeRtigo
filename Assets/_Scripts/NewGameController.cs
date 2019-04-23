using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameController : MonoBehaviour {

	public void newGame(string level)
    {
        SceneManager.LoadScene(level);
    }
}
