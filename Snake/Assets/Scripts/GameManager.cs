using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Snake player;
    public GameObject gameOverScreen;
    public Text highscoreText;

    public int highscore;

    void Update()
    {
        highscoreText.text = "Score: " + highscore;

        if (player.died)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void AddScore(int score)
    {
        highscore += score;
    }


}
