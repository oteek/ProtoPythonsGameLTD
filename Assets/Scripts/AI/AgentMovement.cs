using System.Threading;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float changeDirectionInterval = 1f;

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
        float randomX = Random.Range(-3f, -6f);
        float randomY = Random.Range(1f, 3f);
        float randomZ = Random.Range(-19f, -21f);
        

        targetPosition = new Vector3(randomX, randomY, randomZ);
    }
    
}

