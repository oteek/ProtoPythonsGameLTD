// PrefabGun.cs
using UnityEngine;

public class PrefabGun : MonoBehaviour, IWeapon
{
    public Transform gunTip;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    public void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = gunTip.forward * bulletSpeed;

        // Optionally, set a lifetime for the prefab object
        Destroy(bullet, 5f);
    }

    public void Cleanup() {
        // Additional cleanup if needed
    }
}