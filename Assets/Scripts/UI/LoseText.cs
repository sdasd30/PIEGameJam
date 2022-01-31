using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseText : MonoBehaviour
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
        if (FindObjectOfType<PlayerController>() == null)
        {
            string newText = "You Lose!\n" + "Final Score: " + score.score + "\nFinal Difficulty: " + diff.difficultyLevel;
            text.text = newText;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            text.text = "";
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
