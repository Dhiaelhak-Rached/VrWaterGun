using UnityEngine;

public class EnemyHitHandler : MonoBehaviour
{
    public GameObject cubePrefab; // Reference to the cube prefab to spawn

    // Function called when the enemy is hit by a projectile or damaging object
    public void OnHit()
    {
        // Check if the cube prefab is assigned
        if (cubePrefab != null)
        {
            // Instantiate the cube prefab at the position of the enemy
            Instantiate(cubePrefab, transform.position, Quaternion.identity);

            // Destroy the enemy GameObject
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("Cube prefab not assigned in EnemyHitHandler script.");
        }
    }
}
