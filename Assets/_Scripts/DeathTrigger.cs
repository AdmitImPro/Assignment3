/* Author: Arunan Shan */
/* File: DeathTrigger.cs */
/* Creation Date: November 13, 2015 */
/* Description: This script ends the game once player falls off platform */
/* Last Modified by: November 19, 2015 */
using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
		
			Application.LoadLevel(Application.loadedLevel); //reloads level
		}
	}
}
