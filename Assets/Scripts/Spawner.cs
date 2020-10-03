using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject pipe; //Pipe pref
	public float height;    //Height of spawner
	public float spawnerTime = 1;   //Spawner time
	public float timer = 0;

    void Update()
    {
        if(timer > spawnerTime)
        {
        	GameObject nextPipe = Instantiate(pipe);
        	nextPipe.transform.position = new Vector3(0, Random.Range(-height, height), 0) + transform.position;   //Random pipe spawning
        	Destroy(nextPipe, 3);   //Destroy after 3 sec
        	timer = 0;
        }
        timer += Time.deltaTime;
    }
}
