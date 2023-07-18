using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSteelController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.tag;
        var bulletObject = collision.gameObject;
        var isEffect = bulletObject.GetComponent<BulletController>()?.bulletEffect ?? true;
        if ((tag == "bullet" || tag == "bulletEnemy") && isEffect)
        {
            Destroy(bulletObject);
        }
    }
}