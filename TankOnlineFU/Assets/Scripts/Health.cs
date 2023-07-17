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

	Rigidbody2D rb2D;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

	private void SetHealth()
	{
		currenthHealth = maxHealth;
	}

	public void TakeDamage(int damage = 1)
	{
		currenthHealth -= damage;

		if (currenthHealth <= 0)
		{
			StartCoroutine(Death());

			rb2D.velocity = Vector3.zero;
			//gameObject.GetComponent<Bot>().ToFreezeTank();
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
