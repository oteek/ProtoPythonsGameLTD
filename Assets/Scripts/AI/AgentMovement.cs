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
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= changeDirectionInterval)
        {
            SetNewRandomTarget();
            timer = 0f;
        }
    }

    void SetNewRandomTarget()
    {
        float randomX = Random.Range(-3f, -4f);
        float randomY = Random.Range(1f, 2f);
        float randomZ = Random.Range(-19f, -20f);
        

        targetPosition = new Vector3(randomX, randomY, randomZ);
    }
    
}

