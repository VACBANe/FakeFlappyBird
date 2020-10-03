using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Alerts : MonoBehaviour
{
    public GameObject[] alerts;
    private void Start()
    {
        for(int i = 0; i < 3; i++)
            alerts[i].SetActive(false);
    }

    //alerts[0] --- Skin already purchased
    //alerts[1] --- don't have enough coins
    //alerts[2] --- pls buy skin
    public void ShowAlerts(int alertNum)
    {
        switch(alertNum)
        {
            case 0:
                alerts[0].SetActive(true);
                alerts[1].SetActive(false);
                alerts[2].SetActive(false);
                break;
            case 1:
                alerts[0].SetActive(false);
                alerts[1].SetActive(true);
                alerts[2].SetActive(false);
                break;
            case 2:
                alerts[0].SetActive(false);
                alerts[1].SetActive(false);
                alerts[2].SetActive(true);
                break;
        }
    }

}


