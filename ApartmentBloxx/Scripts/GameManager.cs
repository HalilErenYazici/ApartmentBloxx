using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menu, ui, mainHook;

    public Text scoreText;
    public TextMesh finalScoreText, highScoreText;
    public int score;
    public int highScore;

    void Start()
    {
        highScoreText.text = "" + PlayerPrefs.GetInt("highscore");
    }
    void Update()
    {
        scoreText.text = "floor: " + score.ToString();
        finalScoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();

        HighScore();

        if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void HighScore()
    {
        if (score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }

        highScoreText.text = "" + PlayerPrefs.GetInt("highscore");
    }
    public void Play()
    {
        menu.SetActive(false);
        ui.SetActive(true);
        mainHook.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
