using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField]
	private int maxHealth = 5;

	[SerializeField]
	private int currenthHealth;

	[SerializeField]
	private bool isPlayer;

	public bool hasShield = false;

	Rigidbody2D rb2D;
	AudioSource audio;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		audio = GetComponent<AudioSource>();
	}

	private void SetHealth()
	{
		currenthHealth = maxHealth;
	}

	public void TakeDamage(int damage = 1)
	{
		currenthHealth -= damage;
		
		audio?.Play();

		if (currenthHealth <= 0)
		{
			StartCoroutine(Death());

			rb2D.velocity = Vector3.zero;
		}
	}

	private IEnumerator Death()
	{
		// Clean up some resource
		// ...
		yield return new WaitForSeconds(0.5f);
		// Destory object
		Destroy(gameObject);
	}
}
