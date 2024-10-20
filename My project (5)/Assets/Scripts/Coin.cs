using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
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

    /// Code Review by Dev A 
    // Null Check for ScoreKeeper Instance:
    // Add a null check before calling ScoreKeeper.Instance.OnPickup(points) to prevent errors in case the singleton is not initialized.
    // Use object pooling for coins if many instances are needed in the scene.
}
