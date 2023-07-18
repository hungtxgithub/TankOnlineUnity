using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class WallWaterController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tag = collision.tag;
        if (tag.EndsWith("Item"))
        {
            Destroy(collision.gameObject);
        }
    }
}
