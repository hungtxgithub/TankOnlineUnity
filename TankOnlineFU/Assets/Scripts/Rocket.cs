using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Rocket : MonoBehaviour
{
	public bool CanDestroyEveryThing;

	public float Speed = 1;
	Rigidbody2D rb2D;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		var force = transform.up * Speed;
		rb2D.AddForce(force, ForceMode2D.Impulse);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// Collision with tank
		OnCollisionWithTank(collision.gameObject);
	}

	private void OnCollisionWithTank(GameObject tank)
	{
		var health = tank.GetComponent<Health>();
		if (health != null && !health.hasShield)
		{
			health.TakeDamage(1);
			Destroy(gameObject);
		}
	}
}
