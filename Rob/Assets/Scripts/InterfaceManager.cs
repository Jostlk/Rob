using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    public GameObject Eye;
    public GameObject ObjectiveIndicator;
    public GameObject MoneyCounter;
    public GameObject TabPanel;
    public GameObject GameOverScreen;
    public TextMeshProUGUI Text;
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
    public void GameOver()
    {
        Eye.SetActive(false);
        ObjectiveIndicator.SetActive(false);
        MoneyCounter.SetActive(false);
        TabPanel.SetActive(false);
        GameOverScreen.SetActive(true);
        Text.text = "GAME OVER";
    }
    public void Win()
    {
        Eye.SetActive(false);
        ObjectiveIndicator.SetActive(false);
        MoneyCounter.SetActive(false);
        TabPanel.SetActive(false);
        GameOverScreen.SetActive(true);
        Text.text = "YOU WON!";
    }
}
