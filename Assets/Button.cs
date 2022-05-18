using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public bool appearMode = true;
    private GameObject _otherGameObject;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_otherGameObject == null) return;
            if (appearMode)
            {
                rock1.SetActive(true);
                if(rock2 != null)
                    rock2.SetActive(true);
                if(rock3 != null)
                    rock3.SetActive(true);
            }
            else
            {
                rock1.SetActive(false);
                if(rock2 != null)
                    rock2.SetActive(false);
                if(rock3 != null)
                    rock3.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Possessable"))
        {
            _otherGameObject = collision.gameObject;
            print(_otherGameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Possessable"))
        {
            _otherGameObject = null;
        }
    }
}
