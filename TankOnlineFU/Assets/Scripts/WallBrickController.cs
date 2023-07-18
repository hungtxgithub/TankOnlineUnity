using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBrickController : MonoBehaviour
{
    public int HP = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.tag;
        var bulletObject = collision.gameObject;
        var isEffect = bulletObject.GetComponent<BulletController>()?.bulletEffect ?? true;
        if ((tag == "bullet" || tag == "bulletEnemy") && isEffect)
        {
            HP--;
            Destroy(bulletObject);
            if (HP < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}