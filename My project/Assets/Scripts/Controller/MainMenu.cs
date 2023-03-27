using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton, quitButton;
    
    public void StartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game Play");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
