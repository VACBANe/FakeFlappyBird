using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject gameOver; //game over menu
	public GameObject bigScore; //Big Score 
	public GameObject start;    //Start menu
	public GameObject delProgMenu;  //DelProgress menu
	public GameOverScore gameOverScore;	//GameOverScore script
	public Alerts alerts;		//alerts script
	public GameObject skins;    //Skins menu
	public GameObject brd0, brd1, brd2, brd3;	//Characters
	public GameObject[] prevSkin;   //Preview skin
	public int skinNum;				//Num of skins
	public int charOn = 0;          //defauls skin;
	public int coin;				//coins
	public int currentMoney;		//current money
	public GameObject finalScore;   //Final Score
	public GameObject coinsStart;	//coin counter in Start menu
	public GameObject coinsSkinMenu;//coin counter in Skin menu

	private void Start()
    {
		coin = PlayerPrefs.GetInt("Coins", 0);	//defauld coins
		coinsStart.GetComponent<UnityEngine.UI.Text>().text = coin.ToString();
		skinNum = PlayerPrefs.GetInt("Skin", 0);	//selected skin
		SwitchCharacter(skinNum);
    	start.SetActive(true);
		gameOver.SetActive(false);
    	bigScore.SetActive(false);
		delProgMenu.SetActive(false);
		skins.SetActive(false);
        Time.timeScale = 0;
    }
    public void StartGame()
    {
    	start.SetActive(false);
    	bigScore.SetActive(true);
    	Time.timeScale = 1;
    }
	public void GameOver()
	{
		gameOver.SetActive(true);
		bigScore.SetActive(false);
		gameOverScore.EarnMoney();
		Time.timeScale = 0;
	}
	public void Replay()
	{
		SceneManager.LoadScene(0);
	}
	public void Update() 
	{
		//Skins in shop
		if (skins.activeSelf)
        {
			for (int i = 0; i < 4; i++)
			{
				if (skinNum == i)
				{
					prevSkin[i].SetActive(true);
				}
				else
				{
					prevSkin[i].SetActive(false);
				}
			}
		}
	}
	//DelProgress menu
	public void DelProgMenu()
    {
		delProgMenu.SetActive(true);
	}
	public void DeleteProgress()
    {
		PlayerPrefs.DeleteAll();
		Replay();
	}

	//Skins menu
	public void Skin () 
	{
		start.SetActive(false);
		gameOver.SetActive(false);
    	bigScore.SetActive(false);
    	skins.SetActive(true);
		coinsSkinMenu.GetComponent<UnityEngine.UI.Text>().text = coin.ToString(); //show coins in skinMenu
	}
	//Next skin button
	public void NextSkin()
    {
 		if(0 <= skinNum && skinNum <= 2)
 		{
 			skinNum++;
	        PlayerPrefs.SetInt("Skin", skinNum);
    	}
    	Debug.Log(skinNum);
    }
	//Previous skin button
	public void PrevSkin()
    {
    	if(1 <= skinNum && skinNum <= 3)
 		{
	        skinNum--;
	        PlayerPrefs.SetInt("Skin", skinNum);
    	}
    	Debug.Log(skinNum);
    }

	//Change character
    public void SwitchCharacter(int charON)
    {
    	switch(charON)
    	{
    		case 0:
    			brd0.SetActive(true);
		    	brd1.SetActive(false);
		    	brd2.SetActive(false);
		    	brd3.SetActive(false);
		    	break;
		    case 1:
				brd0.SetActive(false);
				brd1.SetActive(true);
				brd2.SetActive(false);
				brd3.SetActive(false);
		    	break;
		    case 2:
    			brd0.SetActive(false);
		    	brd1.SetActive(false);
		    	brd2.SetActive(true);
		    	brd3.SetActive(false);
		    	break;
		    case 3:
    			brd0.SetActive(false);
		    	brd1.SetActive(false);
		    	brd2.SetActive(false);
		    	brd3.SetActive(true);
		    	break;
    	}
	}

	public void BuySkin()
	{
		switch (skinNum)
		{
			case 0:										//defauld skin
				alerts.ShowAlerts(0);                   //skin already purchased
				break;
			case 1:
				if (coin >= 40)
				{
					if (PlayerPrefs.GetInt("skin2") == 0)				//skin not purchased
					{
						currentMoney = PlayerPrefs.GetInt("Coins", 0);
						PlayerPrefs.SetInt("Coins", currentMoney - 40);
						PlayerPrefs.SetInt("skin2", 1);
						SceneManager.LoadScene(0);
					}
					else
						alerts.ShowAlerts(0);               //skin already purchased
				}
				else												//coin < 40
				{
					if (PlayerPrefs.GetInt("skin2") == 1)			//skin purchased
						alerts.ShowAlerts(0);
                    else  
						alerts.ShowAlerts(1);       //don't have enough money
				}
				break;
			case 2:
				if (coin >= 40)
				{
					if (PlayerPrefs.GetInt("skin3") == 0)               //skin not purchased
					{
						currentMoney = PlayerPrefs.GetInt("Coins", 0);
						PlayerPrefs.SetInt("Coins", currentMoney - 40);
						PlayerPrefs.SetInt("skin3", 1);
						SceneManager.LoadScene(0);
					}
					else
						alerts.ShowAlerts(0);               //skin already purchased
				}
				else                                                //coin < 40
				{
					if (PlayerPrefs.GetInt("skin3") == 1)           //skin purchased
						alerts.ShowAlerts(0);
					else
						alerts.ShowAlerts(1);       //don't have enough money
				}
				break;
			case 3:
				if (coin >= 40)
				{
					if (PlayerPrefs.GetInt("skin4") == 0)               //skin not purchased
					{
						currentMoney = PlayerPrefs.GetInt("Coins", 0);
						PlayerPrefs.SetInt("Coins", currentMoney - 40);
						PlayerPrefs.SetInt("skin4", 1);
						SceneManager.LoadScene(0);
					}
					else
						alerts.ShowAlerts(0);               //skin already purchased
				}
				else                                                //coin < 40
				{
					if (PlayerPrefs.GetInt("skin4") == 1)           //skin purchased
						alerts.ShowAlerts(0);
					else
						alerts.ShowAlerts(1);       //don't have enough money
				}
				break;
		}
	}
	//Selecting skin (Purchased or not)
	public void SelectSkin()
	{
		switch (skinNum)
		{
			case 0:
				SceneManager.LoadScene(0);
				break;
			case 1:
				if (PlayerPrefs.GetInt("skin2") == 1)
					SceneManager.LoadScene(0);
				else { Debug.Log("You doesn't bought this skin");
					alerts.ShowAlerts(2);
				}
				break;
			case 2:
				if (PlayerPrefs.GetInt("skin3") == 1)
					SceneManager.LoadScene(0);
				else { Debug.Log("You doesn't bought this skin");
					alerts.ShowAlerts(2);
				}
				break;
			case 3:
				if (PlayerPrefs.GetInt("skin4") == 1)
					SceneManager.LoadScene(0);
				else { Debug.Log("You doesn't bought this skin");
					alerts.ShowAlerts(2);
				}
				break;
		}
	}
}
