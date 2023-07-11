using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankItemController : MonoBehaviour
{
    public GameObject priceLabel;
    public GameObject mask;
    public TankType TankType;
    private bool OwnTank = false;
    private void FixedUpdate()
    {
        var tankTypes = Inventory.GetInstance().availableTank;
        // cache
        if (!OwnTank)
        {
            OwnTank = tankTypes.Contains(TankType);
        }

        if (OwnTank)
        {
            priceLabel?.SetActive(false);
            mask?.SetActive(false);
        }
    }
}
