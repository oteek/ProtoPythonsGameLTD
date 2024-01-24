using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;          
    
    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        
        Projectile projectileScript = projectile.GetComponent<Projectile>();
       
        if (projectileScript != null)
        {
            projectileScript.speed = 10f;  
        }
    }
}

