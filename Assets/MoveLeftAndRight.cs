using UnityEngine;
using System.Collections; // Ensure this line is included for IEnumerator

public class MoveLeftAndRight : MonoBehaviour
{
    public float speed = 5f; // Adjust this to control the movement speed
    public float stepDistance = 2f; // Adjust this to set the distance for each step
    public float waitTime = 1f; // Adjust this to set the time to wait at each step

    private Vector3 leftPosition;
    private Vector3 rightPosition;
    private bool movingRight = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation; // Freeze Y position and rotation

        leftPosition = transform.position + Vector3.left * stepDistance;
        rightPosition = transform.position + Vector3.right * stepDistance;

        // Start the movement coroutine
        StartCoroutine(MoveCoroutine());
    }

    public void DestroyGhost()
    {
        // Schedule the destruction of this GameObject with a 1-second delay
        StartCoroutine(DestroyAfterDelay(1f));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        Destroy(gameObject); // Destroy the GameObject after the delay
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            Vector3 targetPosition = movingRight ? rightPosition : leftPosition;

            // Move towards the target position
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Wait at the target position
            yield return new WaitForSeconds(waitTime);

            // Change direction
            movingRight = !movingRight;
        }
    }
}
