using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncrementScore()
    {
        score += 1;
        text.SetText("Score: " + score);
    }
}
