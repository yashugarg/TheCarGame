// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform rbpos;
    public float FForce = 40000f;
    public float LRForce = 1000f;
    public float UForce = 200f;
    public Text JumpCount;
    public int Count = 3;

    void Start()
    {
       rb.AddForce(0, 0, FForce * Time.deltaTime);
    }    
    void Update()
    {  
        // rb.velocity = new Vector3(0, 0, 20f);
        if( Input.GetKey("right") )
        {
            // rbpos.Translate(new Vector3(-4f * Time.deltaTime, 0, 0));
            rb.AddForce(LRForce * Time.deltaTime, 0, 0);
        }
        if( Input.GetKey("left") )
        {
            // rbpos.Translate(new Vector3(4f * Time.deltaTime, 0, 0));
            rb.AddForce(-1 * LRForce * Time.deltaTime, 0, 0);

        }
        JumpCount.text = Count.ToString();
        if( Input.GetKeyDown(KeyCode.Space)  )
        {
            if( Count > 0 )
            {
                rb.AddForce(new Vector3(0, UForce * Time.fixedDeltaTime, 0), ForceMode.Impulse);
                Count--;
            }
        }   
        if( rb.position.y < -1 )
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}