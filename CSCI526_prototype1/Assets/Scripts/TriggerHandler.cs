using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public GameController gameController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && gameController != null)
        {
            gameController.GameOver();
        }
    }
}
