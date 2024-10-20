using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;
    [SerializeField] private LayerMask playerLayer;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object's layer matches the player layer
        if ((playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            // Increase the score in the ScoreKeeper
            ScoreKeeper.Instance.OnPickup(points);

            // Destroy the coin object after it's collected
            Destroy(gameObject);
        }
    }
}
