/* Author: Arunan Shan */
/* File: MineController.cs */
/* Creation Date: November 18, 2015 */
/* Description: This script destroys the mine game object on collision with player */
/* Last Modified by: November 19, 2015 */
using UnityEngine;
using System.Collections;

public class MineController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider otherGameObject) 
	{
		if (otherGameObject.tag == "Player") {
			
			
			Destroy(gameObject); //destroys mine object
		}
		
		
	}
}
