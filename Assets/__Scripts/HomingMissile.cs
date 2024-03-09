using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public float speed = 20.0f;
    public float rotateSpeed = 100.0f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    /*target = GameObject.FindGameObjectWithTag("Enemy").transform;

       if (target != null)
       {
        Vector3 direction = target.position - transform.position;
       }

        transform.up =  Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

       transform.position = Vector3.MoveTowards(transform.position, target.position, rotateSpeed * Time.deltaTime);*/
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
       if (target != null)
       {
            Vector3 direction = target.position - rb.position;
            direction.Normalize();
            //Vector3 rotateAmount = Vector3.Cross(transform.forward,direction);
            //rb.angularVelocity = rotateAmount * rotateSpeed;
            transform.position = Vector3.MoveTowards(transform.position, target.position, rotateSpeed * Time.deltaTime);
            rb.velocity = transform.forward * speed;      
       }
       
    }
    
}