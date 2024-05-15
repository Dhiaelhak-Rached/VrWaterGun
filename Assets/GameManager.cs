using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    private int score = 0; // Current score

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to add score
    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        // Optionally, you can update the UI or perform other actions here
    }
}
