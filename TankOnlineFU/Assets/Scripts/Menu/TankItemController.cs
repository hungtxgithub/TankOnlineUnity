using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankItemController : MonoBehaviour
{
    public TextMeshProUGUI priceLabel;
    public GameObject mask;
    public TankType TankType;
    private bool OwnTank = false;
    private void FixedUpdate()
    {
        var tankTypes = Inventory.GetInstance().AvailableTank;
        // cache
        if (!OwnTank)
        {
            OwnTank = tankTypes.Contains(TankType);
            priceLabel.text = TankManager.GetTankPrice(TankType) + "";
        }

        if (OwnTank)
        {
            priceLabel.text = "";
            mask?.SetActive(false);
        }
    }
}
