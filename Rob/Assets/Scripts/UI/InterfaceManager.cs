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
    public TextMeshProUGUI RestartText;
    public PlayerController playerController;
    public CameraController cameraController;
    public DetectionSystem detectionSystem;
    public List<EnemyAI> enemies;
    public AudioSource MaxAnxious;
    public AudioSource BackgroundSound;
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
        OffMovement();
        GameOverScreen.SetActive(true);
        Text.text = "GAME OVER";
    }
    public void Win()
    {
        OffMovement();
        GameOverScreen.SetActive(true);
        Text.text = "YOU WON!";
        RestartText.text = "Press ESC to main menu";
        Invoke("FinalStop", 4);
    }
    public void OffMovement()
    {
        Eye.SetActive(false);
        ObjectiveIndicator.SetActive(false);
        MoneyCounter.SetActive(false);
        TabPanel.SetActive(false);
        playerController.enabled = false;
        cameraController.enabled = false;
        detectionSystem.enabled = false;
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].enabled = false;
            enemies[i].GetComponent<Animator>().enabled = false;
        }
        MaxAnxious.enabled = false;
        BackgroundSound.enabled = false;
    }
    public void FinalStop()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
    }
}
