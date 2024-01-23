using System.Threading;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float changeDirectionInterval = 0.5f;

    private Vector3 targetPosition;
    private float timer;

    void Start()
    {
        SetNewRandomTarget();
    }
    void Update()
    {
        // Move towards the target position smoothly
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if it's time to change direction
        timer += Time.deltaTime;
        if (timer >= changeDirectionInterval)
        {
            SetNewRandomTarget();
            timer = 0f;
        }
    }

    void SetNewRandomTarget()
    {
        // Generate new random target position within a range
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        

        targetPosition = new Vector3(randomX, randomY);
    }
    
}

