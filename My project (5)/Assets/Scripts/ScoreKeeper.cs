using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper: MonoBehaviour
{
    public static ScoreKeeper Instance { get; private set; }
    public event Action<int> ScoreChanged;

    private int currentScore;

    public int CurrentScore
    {
        get { return currentScore; }
        private set
        {
            currentScore = value;
            ScoreChanged?.Invoke(currentScore);
        }
    }

    private void Awake()
    {
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

    public void OnPickup(int points)
    {
        CurrentScore += points;
    }

    // New GetScore() method
    public int GetScore()
    {
        return CurrentScore;
    }
}
