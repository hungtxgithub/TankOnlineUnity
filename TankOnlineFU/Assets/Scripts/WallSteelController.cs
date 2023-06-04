using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSteelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.tag;
        if (tag == "bullet" || tag == "bulletEnemy")
        {
            var bulletObject = collision.gameObject;
            Destroy(bulletObject);
        }
    }
}
