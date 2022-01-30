using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public float score;  // everyone has the same score

    // Use this for initialization
    internal void Start()
    {

    }

    public void AddToScore(float points)
    {
        score += points;
    }
    public void ResetScore()
    {
        score = 0;
    }
}