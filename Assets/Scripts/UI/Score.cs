using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI text;
    ScoreTracker score;
    Difficulty diff;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        score = FindObjectOfType<ScoreTracker>();
        diff = FindObjectOfType<Difficulty>();
    }

    // Update is called once per frame
    void Update()
    {
        string newText = "Score: " + score.score + "\nDifficulty: " + diff.difficultyLevel; 
        text.text = newText;
    }
}
