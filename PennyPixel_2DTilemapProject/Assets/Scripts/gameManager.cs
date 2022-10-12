/*
 * Zach Wilson
 * Assignment 5A
 * This is an adaptation of the gemBehavior script to utilize for the final goal gem
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
	public bool GameOver = false;
	public Text Scoreboard;
	public Text GameOverText;
	private scoreManager displayScoreScript;

	[Header("References")]
	public GameObject gemVisuals;
	public GameObject collectedParticleSystem;
	public CircleCollider2D gemCollider2D;

	private float durationOfCollectedParticleSystem;


	void Start()
	{
		
		displayScoreScript = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<scoreManager>();
		Scoreboard = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<Text>();
		GameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
		durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;
	}

    private void Update()
    {
		if (GameOver)
		{
			ManageUI();
		}
	}

    void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag("Player"))
		{
			GemCollected();
			GameOver = true;
		}
	}

	void GemCollected()
	{
		gemCollider2D.enabled = false;
		gemVisuals.SetActive(false);
		collectedParticleSystem.SetActive(true);
		Invoke("DeactivateGemGameObject", durationOfCollectedParticleSystem);

	}

	void DeactivateGemGameObject()
	{
		gameObject.SetActive(false);
	}

	void ManageUI()
    {
		Scoreboard.text = "";
		GameOverText.text = "Game Over!" + "\n" + "Score: " + displayScoreScript.score + "\n" + "Press R to Restart";
	}
}
