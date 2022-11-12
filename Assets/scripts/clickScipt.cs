using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickScipt : MonoBehaviour
{

    public shopScript shop;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.collider.gameObject.CompareTag("shopListing"))
                {
                    shop.rerollShop();
                }
                if (hit.collider.gameObject.CompareTag("refresh"))
                {
                    shop.rerollShop();
                }
            }

        }
    }
}
