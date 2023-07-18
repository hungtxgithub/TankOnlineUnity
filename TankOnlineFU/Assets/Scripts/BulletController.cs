using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Bullet Bullet { get; set; }
    public GameObject bulletExplosion;

    public GameObject bulletExplosionTarget;
    public int MaxRange { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void OnDestroy()
    {
        var pos = transform.position;
        var explosion = GameObject.Instantiate(bulletExplosion, pos, Quaternion.identity);
        Destroy(explosion, 0.3f);
    }

    // Update is called once per frame
    private void Update()
    {
        DestroyAfterRange();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		OnCollisionWithTank(collision);
	}

	private void OnCollisionWithTank(Collider2D collider)
	{
		var health = collider.gameObject.GetComponent<Health>();
        var haveshield = collider.gameObject.GetComponent<TankMover>()?.shield_2.activeInHierarchy;

        if (health != null && bulletExplosionTarget.name != collider.name )
		{
            if (haveshield == false)
            {
			    health.TakeDamage(1);
            }

			Destroy(gameObject);
		}
	}

	private void DestroyAfterRange()
    {
        var currentPos = gameObject.transform.position;
        var initPos = Bullet.InitialPosition;
        switch (Bullet.Direction)
        {
            case Direction.Down:
                if (initPos.y - MaxRange >= currentPos.y)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Up:
                if (initPos.y + MaxRange <= currentPos.y)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Left:
                if (initPos.x - MaxRange >= currentPos.x)
                {
                    Destroy(gameObject);
                }

                break;
            case Direction.Right:
                if (initPos.x + MaxRange <= currentPos.x)
                {
                    Destroy(gameObject);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}