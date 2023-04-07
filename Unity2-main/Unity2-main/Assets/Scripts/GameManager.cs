using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameObject loseUI;
    public int points = 0;
    public TextMeshProUGUI scoreText, spaceToStartText, bestScoreText;
   
    public bool gameOn, deathMenu;
   
    


    private void Start()
    {
        gameOn = false;
        Time.timeScale = 0;
    }
    public void StartGame()
    {
       
       
        Time.timeScale = 1;
        
    }

    private void ShowLoseUI()
    {
        loseUI.SetActive(true);
    }

    

    public void RepeatGame()
    {
        deathMenu = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void OnGameOver()
    {
        if(points > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", points);
        }
        bestScoreText.text = "Best Score: \n" + PlayerPrefs.GetInt("Score");
        ShowLoseUI();
        Time.timeScale = 0;
        gameOn = false;
        deathMenu = true;
    }

    public void UpdateScore()
    {
        points++;
        scoreText.text = points.ToString();
    }
    
}
