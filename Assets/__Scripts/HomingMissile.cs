using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;
    public float rotateSpeed = 100.0f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
    //    target = GameObject.FindGameObjectWithTag("Enemy").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        target = GameObject.FindGameObjectWithTag("Enemy").transform;

       if (target != null)
       {
        Vector3 direction = target.position - transform.position;
       }

       transform.position = Vector3.MoveTowards(transform.position, target.position, rotateSpeed * Time.deltaTime);
    }
}