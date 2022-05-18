using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Possessed : MonoBehaviour
{
    public GameObject player;
    public bool isPossessed;
    public GameObject camera;
    private void Update()
    {
        if (isPossessed && Input.GetButtonDown("Possess"))
        {
            isPossessed = false;                 
            player.GetComponent<PossessionController>().ReturnPossess();
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            camera.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
            if (gameObject.GetComponent<HumanMovementController>() != null)
                gameObject.GetComponent<HumanMovementController>().enabled = false;
            else if (gameObject.GetComponent<BatMovementController>() != null)
            {
                gameObject.GetComponent<BatMovementController>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
    }

    public void BePossessed()
    {
        isPossessed = true;
        camera.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        if (gameObject.GetComponent<HumanMovementController>() != null)
            gameObject.GetComponent<HumanMovementController>().enabled = true;
        else if (gameObject.GetComponent<BatMovementController>() != null)
        {
            gameObject.GetComponent<BatMovementController>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
