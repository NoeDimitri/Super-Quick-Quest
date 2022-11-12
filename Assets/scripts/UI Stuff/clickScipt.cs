using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickScipt : MonoBehaviour
{

    public shopScript shop;
    private bool clickable;

    private void Start()
    {
        clickable = true;
    }

    void Update()
    {

        //Code I stole
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null && clickable)
            {
                if(hit.collider.gameObject.CompareTag("shopListing"))
                {
                    hit.collider.gameObject.GetComponent<shopListing>().selectListing();
                }

                if (hit.collider.gameObject.CompareTag("refresh"))
                {
                    shop.rerollShop();
                }
            }

        }
    }
    private void OnEnable()
    {
        shopTimer.timerFinished += disablePlay;
    }
    private void OnDisable()
    {
        shopTimer.timerFinished -= disablePlay;
    }

    void disablePlay()
    {
        clickable = false;
    }



}
