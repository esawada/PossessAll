using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessionController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private GameObject _otherGameObject;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Possess();
    }
    private void Possess()
    {
        if (Input.GetButtonDown("Possess"))
        {
            if (_otherGameObject == null) return;
            _otherGameObject.GetComponent<Possessed>().BePossessed();
            gameObject.GetComponent<GhostMovementController>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void ReturnPossess()
    {
        gameObject.GetComponent<GhostMovementController>().enabled = true;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Possessable"))
        {
            _otherGameObject = collision.gameObject;
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
