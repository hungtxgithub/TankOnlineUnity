using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomItems : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ls;

    float timer = 0f;
    float delay = 10f; // D?ng 60 giây

    Vector2 rdVt2;


    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {

        timer += Time.deltaTime;
        if (timer > delay )
        {
            rdVt2 = new Vector2(Random.Range(-8, 8), Random.Range(-4.5f, 4.5f));
            var mapLs = GameObject.FindGameObjectsWithTag("Map");
            var itemLs = GameObject.FindGameObjectsWithTag("item");
            var check = mapLs.Where(x => x.transform.position.x >= (rdVt2.x - 0.8f) && x.transform.position.x <= (rdVt2.x + 0.8f) && x.transform.position.y >= (rdVt2.y - 0.8f) && x.transform.position.y <= (rdVt2.y + 0.8f)).FirstOrDefault();
            var checkItem = itemLs.Where(x => x.transform.position.x >= (rdVt2.x - 0.6f) && x.transform.position.x <= (rdVt2.x + 0.6f) && x.transform.position.y >= (rdVt2.y - 0.6f) && x.transform.position.y <= (rdVt2.y + 0.6f)).FirstOrDefault();

            if (check == null)
            {
                // Th?c hi?n hành ??ng c?a b?n ? ?ây
                Instantiate(random(), rdVt2, Quaternion.identity);

                // Reset timer
                timer = 0f;
            }

        }
    }

    public GameObject random()
    {
        return ls[Random.Range(0, ls.Count)];
    }


}
