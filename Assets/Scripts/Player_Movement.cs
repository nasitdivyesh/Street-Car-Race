using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Transform Transform;
    public float speed = 0.5f;
    public float rotationSpeed = 5f;
    public Score_Mangamer scoreValue;

    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
         Movement();
         Clamp();
    }
    void Movement()
    {
          // Player  movement
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime,0,0);
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,0,60),rotationSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed * Time.deltaTime,0,0);
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,0,-230 ),rotationSpeed * Time.deltaTime);
        }

        if(transform.rotation.z !=90)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,0,90), 12f * Time.deltaTime);
        }

    }
        
    
    void Clamp()
    {
        // Manual Way
        // if(transform.position.x<-1.9f)
        // {
        //     transform.position = new Vector3(-1.9f,transform.position
        //     .y,transform.position.z);
        // }
        // if(transform.position.x > +1.9f)
        // {
        //     transform.position = new Vector3(1.9f,transform.position
        //     .y,transform.position.z);
        // }


        // Unity Inbuilt featuer
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x,-1.9f,1.9f);
        transform.position  = pos;
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cars")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
         if(collision.gameObject.tag == "Coin")
        {
            scoreValue.score += 10;
            Destroy(collision.gameObject);
        }

    }
}


