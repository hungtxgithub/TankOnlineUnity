using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBrickController : MonoBehaviour
{
    public int HP = 2;

    public bool isEffect = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.tag;
        var bulletObject = collision.gameObject;
        if ((tag == "bullet" && isEffect) || tag == "bulletEnemy")
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