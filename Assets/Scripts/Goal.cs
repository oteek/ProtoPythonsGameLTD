using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int goals = 0;
    public GameObject ballPrefab;
    public Transform where;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
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
            goals++;
            Destroy(collision.gameObject);
            GameObject clone = Instantiate(ballPrefab, where.position, Quaternion.identity);
        }
    }
}
