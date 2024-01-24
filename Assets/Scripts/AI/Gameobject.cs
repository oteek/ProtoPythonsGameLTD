using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 0.5f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
