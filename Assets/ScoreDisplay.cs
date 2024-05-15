using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        // Find the TextMeshPro component within the child objects of the Canvas
        scoreText = GetComponentInChildren<TextMeshProUGUI>();

        // Ensure the score text is initially set to 0
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        // Update the text to display the current score
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
        else
            Debug.LogError("Score Text component not found!");
    }
}
