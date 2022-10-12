/*
 * Zach Wilson
 * Assignment 5A
 * This is a script that controlles the collectable gem behavior and I modified it to increment the score when a gem gets collected
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
	private scoreManager displayScoreScript;

	[Header("References")]
	public GameObject gemVisuals;
	public GameObject collectedParticleSystem;
	public CircleCollider2D gemCollider2D;

	private float durationOfCollectedParticleSystem;


	void Start()
	{
		displayScoreScript = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<scoreManager>();
		durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;
	}

	void OnTriggerEnter2D(Collider2D theCollider)
	{
		if (theCollider.CompareTag ("Player")) {
			GemCollected ();
		}
	}

	void GemCollected()
	{
		gemCollider2D.enabled = false;
		gemVisuals.SetActive (false);
		collectedParticleSystem.SetActive (true);
		displayScoreScript.score++;
		Invoke ("DeactivateGemGameObject", durationOfCollectedParticleSystem);

	}

	void DeactivateGemGameObject()
	{
		gameObject.SetActive (false);
	}
}
