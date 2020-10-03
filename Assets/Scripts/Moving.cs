using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
	public float movespeed = 1; //Pipe moving speed

    void Update()
    {
        transform.position += Vector3.left * movespeed * Time.deltaTime;    //Pipe moving
    }
}