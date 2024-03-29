using System.Threading;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    public float speed = 4f;
    public float changeDirectionInterval = 3f;

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
        float randomX = Random.Range(0f, -4f);
        float randomY = Random.Range(1f, 5f);
        float randomZ = Random.Range(-24f, -14f);
        

        targetPosition = new Vector3(randomX, randomY, randomZ);
    }
    
}

