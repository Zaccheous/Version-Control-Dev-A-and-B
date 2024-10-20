using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;
    public GameObject player; // Assign in the inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // Invoke score increase and destroy the coin
            ScoreKeeper.Instance.OnPickup(points);
            Destroy(gameObject);
        }
    }
}
