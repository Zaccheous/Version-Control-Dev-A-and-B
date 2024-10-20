using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper: MonoBehaviour
{
    public static ScoreKeeper Instance { get; private set; }
    private int currentScore;
    // Start is called before the first frame update
    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int GetScore() => currentScore;

    public void OnPickup(int points)
    {
        currentScore += points;
    }
}
