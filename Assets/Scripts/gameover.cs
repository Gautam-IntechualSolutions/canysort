using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    public Text ScoreText;
    public Text BestScoreText;


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.GameOverSound();

        ScoreText.text = "Score " + GameManager.Instance.ScoreCounter;

        if (PlayerPrefs.GetInt("Score") < GameManager.Instance.ScoreCounter)
            PlayerPrefs.SetInt("Score", GameManager.Instance.ScoreCounter);

        BestScoreText.text = "Best Score " + PlayerPrefs.GetInt("Score");

    }


    public void onClickMainGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}
