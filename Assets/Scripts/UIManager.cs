using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sprite[] livesSprite;
    [SerializeField] private Image lives;
    [SerializeField] private Text scoreText;
    private int score;
    public GameObject titleScreen;


    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
    }
    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        score = 0;
        scoreText.text = "Score : " + score;
    }

    public void UpdateLives(int currentLives)
    {
        if (currentLives >= 0)
            lives.sprite = livesSprite[currentLives];
    }

    public void UpdateScore(int scoreVal)
    {
        score += scoreVal;
        scoreText.text = "Score : " + score;
    }
}
