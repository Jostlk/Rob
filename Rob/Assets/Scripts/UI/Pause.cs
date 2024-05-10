using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] CameraController cameraController;

    private float startSens;

    void Start()
    {
        startSens = cameraController.sensitivity;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cameraController.sensitivity = 0;
    }
    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraController.sensitivity = startSens;
    }
    void Update()
    {
        if (!gameOverMenu.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseMenu.activeInHierarchy)
                {
                    UnpauseGame();
                }
                else
                { 
                    PauseGame();
                }
            }
        }
    }
}
