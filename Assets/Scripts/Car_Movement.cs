using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Movement : MonoBehaviour
{
    public Transform Transform;
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Transform = GetComponent <Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime,0);
        if(transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
    
}
