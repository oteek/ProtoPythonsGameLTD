using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOBCheck : MonoBehaviour
{
    public int misses = 0;
    public GameObject ballPrefab;
    public Transform where;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if we collide with ball, we can shoot it
        if (collision.gameObject.tag == "ball")
        {
            misses++;
            Destroy(collision.gameObject);
            GameObject clone = Instantiate(ballPrefab, where.position, Quaternion.identity);
            clone.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        }
    }
}
