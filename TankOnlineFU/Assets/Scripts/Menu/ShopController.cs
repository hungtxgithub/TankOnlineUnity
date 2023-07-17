using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public TextMeshProUGUI money;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // Make sure not pause 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        money.text = Inventory.GetInstance().Money.ToString();    
    }
}
