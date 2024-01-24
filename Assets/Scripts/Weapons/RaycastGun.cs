// RaycastGun.cs
using UnityEngine;

public class RaycastGun : MonoBehaviour, IWeapon
{
    
    public Transform gunTip;
    public LayerMask shootableLayer;
    public AudioClip shootSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add an AudioSource component if not already present
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the audio clip for shooting
        audioSource.clip = shootSound;
    }
    public void Shoot() {
        RaycastHit hit;

        if (Physics.Raycast(gunTip.position, gunTip.forward, out hit, Mathf.Infinity, shootableLayer)) {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Enemy") {
                Destroy(hit.collider.gameObject);       //laikinas kodas
            }
        }

        // Play the shooting sound
        if (audioSource != null && shootSound != null)
        {
            audioSource.Play();
        }

        // Draw the ray for visualization purposes
        Debug.DrawRay(gunTip.position, gunTip.forward * 100f, Color.red, 0.5f);
    }

    public void Cleanup() {
        // Additional cleanup if needed
    }
}