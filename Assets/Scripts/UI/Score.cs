using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI text;
    ScoreTracker score;
    Difficulty diff;
    float mHealth;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        score = FindObjectOfType<ScoreTracker>();
        diff = FindObjectOfType<Difficulty>();
        //mHealth = FindObjectOfType<PlayerController>().GetComponent<Attackable>().health;
    }

    // Update is called once per frame
    void Update()
    {
        mHealth = FindObjectOfType<PlayerController>().GetComponent<Attackable>().health;
        if (FindObjectOfType<PlayerController>() != null)
        {
            string newText = "Score: " + score.score + "\nDifficulty: " + diff.difficultyLevel + "\nHealth:" + mHealth;
            text.text = newText;
        }
        else
        {
            text.text = "";
        }
    }
}
