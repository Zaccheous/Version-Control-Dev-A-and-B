using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask player2Layer;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object's layer matches Player 1 or Player 2
        if ((playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            // Increase Player 1's score
            ScoreKeeper.Instance.OnPlayerPickup(points);
            Destroy(gameObject);
        }
        else if ((player2Layer.value & (1 << other.gameObject.layer)) > 0)
        {
            // Increase Player 2's score
            ScoreKeeper.Instance.OnPlayer2Pickup(points);
            Destroy(gameObject);
        }
    }
    /// Code Review by Dev A 
    // Null Check for ScoreKeeper Instance:
    // Add a null check before calling ScoreKeeper.Instance.OnPickup(points) to prevent errors in case the singleton is not initialized.
    // Use object pooling for coins if many instances are needed in the scene.
}
