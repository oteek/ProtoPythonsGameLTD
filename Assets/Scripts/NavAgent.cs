using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent m_Agent;
    public Transform where;
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Agent != null) {
            m_Agent.destination = where.position;
        }
        if (Vector3.Distance(m_Agent.destination, transform.position) < 0.5f) {
            m_Agent.destination = transform.position;
            Debug.Log("arrived at destination");
        }
    }
}
