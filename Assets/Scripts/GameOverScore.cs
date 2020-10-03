using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
	public Text smscore;    //small score
	public Text highscore;  //high score
    public Medalscript medalHs; //medals script
    public GameManager gameManager;
    public int newcoins;

    void Start()
    {
        medalHs.GiveMedal(Score.score);
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); //Highscore from prefs
    }

    void Update()
    {
        smscore.text = Score.score.ToString();
        if(Score.score > PlayerPrefs.GetInt("HighScore", 0))    //Best Score
        {
        	PlayerPrefs.SetInt("HighScore", Score.score);
        	highscore.text = Score.score.ToString();
        }
    }
    public void EarnMoney()
    {
        newcoins = PlayerPrefs.GetInt("Coins", 0);
        PlayerPrefs.SetInt("Coins", (newcoins + Score.score));
    }

}