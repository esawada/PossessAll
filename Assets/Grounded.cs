using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private HumanMovementController human;
    void Start()
    {
        human = gameObject.transform.parent.gameObject.GetComponent<HumanMovementController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            human.isJumping = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            human.isJumping = true;
        }
    }
}
