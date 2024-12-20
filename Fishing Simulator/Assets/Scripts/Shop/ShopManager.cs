using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public bool isShopOpen;

    private void OnEnable()
    {
        isShopOpen = true;
    }
    private void OnDisable()
    {
        isShopOpen = false;
    }
}
