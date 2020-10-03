using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
	public GameManager gameManager;
	public float force = 1; //Force of jumping
	Rigidbody2D rb;
	public AudioClip jumpSound, gameoverSound;  //Sounds

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) | (Input.GetKeyDown("space")))   //If pressed Space or Left Mouse Button
        {
        	if(Time.timeScale != 0)         //If freezetime disabled
        	{
        		GetComponent<AudioSource>().clip = jumpSound;
        		GetComponent<AudioSource>().Play ();
        	}
        	rb.velocity = Vector2.up * force;      //Jump
    	}
    	float angle = 0;        //Bird Rotation
     	if (rb.velocity.y <= 0) 
     	{
            angle = Mathf.Lerp(0, -90, -rb.velocity.y / force);
     	}
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    	GetComponent<AudioSource>().clip = gameoverSound;
        GetComponent<AudioSource>().Play ();
    	gameManager.GameOver();
    }
}
