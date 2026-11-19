using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    /* make a private rigidbody variable to use the 
    components of rigidbody throughout the code */
    Rigidbody playerRB;
    //make a variable to use throughout your project
    public float horizontalInput;
    public float Jump = 5.5f;
    public float Speed = 10.0f; 
    //identify your player throughout different scripts
    public GameObject player;
    public bool Grounded;
    // Start is called before the first frame update
    void Start()
    {
        //gets the information of the rigidbody form unity.
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       horizontalInput = Input.GetAxis("Horizontal");
       transform.Translate(Vector3.left * Time.deltaTime * -Speed * horizontalInput);
       
       //if player is touching the grounhd, allow them to jump
       if(Grounded == true)
       { 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            /*allows the player to jump based on 
            the amount of force added(the 10.0 being multiplied)
            and which direction force is being applied
            */
            playerRB.AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
            //if player isnt grounded, turn 'grounded' false and restrict code from playing
            Grounded = false;
            
        }
       }
        
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
        }

                
    }
}
