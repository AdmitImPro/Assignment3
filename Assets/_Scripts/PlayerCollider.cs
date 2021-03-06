﻿/* Author: Arunan Shan */
/* File: PlayerCollider.cs */
/* Creation Date: November 13, 2015 */
/* Description: This script controls the score, sound & collider with objects */
/* Last Modified by: November 19, 2015 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerCollider : MonoBehaviour {
	
	//PUBLIC INSTANCE VARIABLES
	public Text scoreText;      //makes a reference to scoreboard
	public Text livesText;
	public Text gameOverText;
	public Text finalScoreText;
	public Text restartText;
	public Text winnerText;
	public int  scoreValue = 0;
	public int  livesValue = 1;
	public GameObject other;
	public CharacterController controller; //makes a reference to player controller
	
	
	private bool gameOver;
	private bool restart;



	private AudioSource[] soundClips; //array of sound clips
	private AudioSource coin, dead, explosion, life, death;

	
	// Use this for initialization
	void Start () {

	
		restart = false;
		this._SetScore ();
		this.gameOverText.enabled = false; // Hides end game text 
		this.finalScoreText.enabled = false;
		this.restartText.enabled = false;
		this.winnerText.enabled = false;

		this.soundClips = gameObject.GetComponents<AudioSource>();  //get audio sources from player
		this.dead = soundClips[0];
		this.coin = soundClips[1];
		this.explosion = soundClips[2];
		this.life = soundClips[3];
		this.death = soundClips [4];

		
		UpdateScore();
		UpdateLives();
	}
	
	// Update is called once per frame
	void Update () {


		
		if (restart == true) 
		{
		
			if(Input.GetKeyDown (KeyCode.R))
			{
				
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		
	}
	
	
	// When player scores a point
	public void GainScore(int newScoreValue)
	{
		scoreValue += newScoreValue;
		UpdateScore();
	}
	
	// Updates score value from above
	public void UpdateScore()
	{
		scoreText.text = "Score: " + scoreValue; //updates score
	}
	
	// When player collides with a Enemy
	public void LoseLife(int newLifeValue)
	{
		livesValue -= newLifeValue;  
		UpdateLives();
	}

	public void UpdateLives()
	{
		livesText.text = "Lives: " + livesValue; //updates life value
		
	}
	void OnTriggerEnter (Collider other) {
		
		if (other.tag == "Coin") {
			this.coin.Play (); // plays coin audio
			this.scoreValue += 10; // adds 10 points

		}

		if (other.tag == "Health") {
			this.life.Play (); //plays life audio
			this.livesValue += 1; // adds 1 life
			
		}
		if (other.tag == "Mine") {
			this.explosion.Play ();
			this.livesValue -= 1; // loose 1 life
			if(this.livesValue <= 0) {  //ends the game when you have 0 or less lives
				this.death.Play ();  //plays death audio
				this._EndGame();
			}


			
		}
		if (other.tag == "Death") {
			this.death.Play ();
			restart = true;
			this.scoreText.enabled = false;
			this.livesText.enabled = false;
			this.gameOverText.enabled = true; // Makes game over, final score, restart text appear when game ends 
			this.finalScoreText.enabled = true;
			this.restartText.enabled = true;
			this.finalScoreText.text = "Score: " + this.scoreValue;
			
		}


			
		this._SetScore ();

		if (this.scoreValue == 100) {

			restart = true;

			this.scoreText.enabled = false;
			this.livesText.enabled = false;
			this.winnerText.enabled = true;// Makes game over, final score, restart text appear when game ends 
			this.finalScoreText.enabled = true;
			this.restartText.enabled = true;

			this.finalScoreText.text = "Score: " + this.scoreValue;


		}
	}
	
	
	// PRIVATE METHODS
	private void _SetScore() {
		this.scoreText.text = "Score: " + this.scoreValue;
		this.livesText.text = "Lives: " + this.livesValue;
	}




	//ends game displays game over text
	private void _EndGame() {

		this.dead.Play ();
		this.controller.enabled = false;


		
		
		restart = true;


		this.scoreText.enabled = false;
		this.livesText.enabled = false;
		this.gameOverText.enabled = true; // Makes game over, final score, restart text appear when game ends 
		this.finalScoreText.enabled = true; //enables final score
		this.restartText.enabled = true;  //displays restart text
		this.finalScoreText.text = "Score: " + this.scoreValue; //displays final score after calculations
		
		
		
		
	}
}

