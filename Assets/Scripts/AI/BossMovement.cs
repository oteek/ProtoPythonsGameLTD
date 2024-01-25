using System.Diagnostics;
using System.Threading;
using UnityEngine;


public class BossMovement : MonoBehaviour
{
    public float speed = 1f;
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
        float randomX = Random.Range(-11f, -11f);
        float randomY = Random.Range(2f, 2f);
        float randomZ = Random.Range(-24f, -14f);
        

        targetPosition = new Vector3(randomX, randomY, randomZ);
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}