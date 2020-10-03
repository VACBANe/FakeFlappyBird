using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medalscript : MonoBehaviour
{
    public GameObject[] medal;

    public void GiveMedal(int number)
    {
        for(int i = 0; i < 4; i++)
        {
            medal[i].SetActive(false);
        }
        if (number >= 40) medal[3].SetActive(true);
        else if (number >= 30) medal[2].SetActive(true);
            else if (number >= 20) medal[1].SetActive(true);
                else if (number >= 10) medal[0].SetActive(true);
    }
}
