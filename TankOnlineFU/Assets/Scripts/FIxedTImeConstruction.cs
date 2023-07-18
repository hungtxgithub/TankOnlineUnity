using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIxedTImeConstruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
