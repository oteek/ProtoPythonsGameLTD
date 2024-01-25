using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public GameObject bulletPrefab; // Prefab for the bullet
    public Transform firePoint; // Point where the bullet is instantiated
    public float bulletSpeed = 50f; // Speed of the bullet

    public float shootingCooldown = 3f; // Cooldown between shots
    private float timeSinceLastShot;

    void Update()
    {
        if (player != null)
        {
            // Check if enough time has passed since the last shot
            if (Time.time - timeSinceLastShot > shootingCooldown)
            {
                // Shoot a bullet
                Shoot();
                timeSinceLastShot = Time.time; // Update the time of the last shot
            }
        }
    }

    void Shoot()
    {
        // Instantiate a bullet at the firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Set the bullet's speed
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;
        }
            Destroy(bullet, 3f);
        // Optionally, you can add additional logic such as setting the bullet's damage, effects, etc.
    }
}

