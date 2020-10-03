using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
	public AudioClip plusScore;
    void OnTriggerEnter2D(Collider2D collision)
    {	
    	GetComponent<AudioSource>().clip = plusScore;
		GetComponent<AudioSource>().Play ();
    	Score.score++;
    }
}