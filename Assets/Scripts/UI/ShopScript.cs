using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject shop;
    // Start is called before the first frame update
    void Start()
    {
        shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shopMenu()
    {
        shop.SetActive(true);
    }
    
    public void closeShop()
    {
        shop.SetActive(false);
    }
}
