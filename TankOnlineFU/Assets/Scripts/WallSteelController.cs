using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSteelController : MonoBehaviour
{
    public bool isEffect = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.tag;
        var bulletObject = collision.gameObject;
        if ((tag == "bullet" && isEffect) || tag == "bulletEnemy") 
        {
            Destroy(bulletObject);
        }
    }
}