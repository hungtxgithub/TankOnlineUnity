using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItems : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ls;

    float timer = 0f;
    float delay = 10f; // D?ng 60 giây
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            // Th?c hi?n hành ??ng c?a b?n ? ?ây
            Instantiate(random(), new Vector2(Random.Range(-11, 11), Random.Range(-4, 4)), Quaternion.identity);
            
            // Reset timer
            timer = 0f;
        }
    }

    public GameObject random()
    {
        return ls[Random.Range(0, ls.Count)];
    }

}
