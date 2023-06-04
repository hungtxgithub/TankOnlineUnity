using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Bullet Bullet { get; set; }
    public GameObject bulletExplosion;

    public int MaxRange { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        DestroyAfterRange();
    }

    private void OnDestroy()
    {
        var pos = gameObject.transform.position;
        var explosion = GameObject.Instantiate<GameObject>(bulletExplosion, pos, Quaternion.identity);
        GameObject.Destroy(explosion, 0.2f);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
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
                    DestroyBullet();
                }

                break;
            case Direction.Up:
                if (initPos.y + MaxRange <= currentPos.y)
                {
                    DestroyBullet();
                }

                break;
            case Direction.Left:
                if (initPos.x - MaxRange >= currentPos.x)
                {
                    DestroyBullet();
                }

                break;
            case Direction.Right:
                if (initPos.x + MaxRange <= currentPos.x)
                {
                    DestroyBullet();
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}