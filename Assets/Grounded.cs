using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private HumanMovementController _humanMovementController;
    void Start()
    {
        _humanMovementController = gameObject.transform.parent.gameObject.GetComponent<HumanMovementController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            _humanMovementController.isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            _humanMovementController.isJumping = true;
        }
    }
}
