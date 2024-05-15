using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnEscape : MonoBehaviour
{
    public TextMeshProUGUI Text;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Text.text == "GAME OVER")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                Time.timeScale = 1;
                AudioListener.volume = 1;
                SceneManager.LoadScene(0);
            }
        }
    }
}
