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
		//var force = new Vector2(-1 * Speed, 0);
		var force = transform.up * Speed;
		rb2D.AddForce(force, ForceMode2D.Impulse);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Collision with tank
		OnCollisionWithTank(collision);
	}

	private void OnCollisionWithTank(Collision2D collision)
	{
		var health = collision.gameObject.GetComponent<Health>();
		if (health != null)
		{
			health.TakeDamage(1);
		}
	}
}
