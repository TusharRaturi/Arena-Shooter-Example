using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Rigidbody body;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Up");
        //if (Input.GetKey(KeyCode.W))
            //transform.position += speed * Vector3.forward * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + speed * Vector3.forward * Time.deltaTime);
    }
}
