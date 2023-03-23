using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreText, currentScoreText, finalScore, record;
    [SerializeField] private GameObject pauseMenu, gameOver;
    [SerializeField] private Button resumeButton, restartButton, pauseButton, quitButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetText();
        GameOverMenu();
        SetCurrenScoreText();
        SetFinalScoreText();
        SetRecord();
    }

    void SetText()
    {
        scoreText.text = PlayerController.instance.personalScore.ToString();
    }

    void SetCurrenScoreText()
    {
        currentScoreText.text = PlayerController.instance.personalScore.ToString();
    }

    void SetFinalScoreText()
    {
        finalScore.text = PlayerController.instance.personalScore.ToString();
    }

    void SetRecord()
    {
        record.text = "" + GameManager.gameManager._GetHighScore();
    }

    void GameOverMenu()
    {
        if (PlayerController.instance.isAlive == false)
        {
            gameOver.SetActive(true);
        }
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game Play");
    }

    public void QuitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
