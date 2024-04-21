using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(0);
    }
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log($"Loaded scene - {sceneName}");
    }
}
