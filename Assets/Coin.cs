using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust this to change the rotation speed
    public int scoreValue = 10; // The score value added when the coin is destroyed
    public Text scoreText; // Reference to the UI Text component displaying the score

    private void Update()
    {
        // Rotate the coin around its local Y axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Add score
            GameManager.instance.AddScore(scoreValue);

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
