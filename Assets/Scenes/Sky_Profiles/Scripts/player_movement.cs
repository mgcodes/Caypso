using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class player_movement : MonoBehaviour
{

    private int lane = 2;
    public float verticalv = 0;
    private int track;
    public float horizontalv;
    public float speed;
      private float maxspeed=50;
    
    private bool inair = false;
    private bool isgrounded = false;

    public float thrust;      
    private Rigidbody  rb;
    private bool pause = false;

    public GameObject explosion;

    
    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();



    }

    // Update is called once per frame
        void Update()
    {
        //velocity parameters for forward and horizontal motion
         GetComponent<Rigidbody>().velocity = new Vector3 (0,verticalv,speed);
               
        if(speed<maxspeed)
        {
            speed = speed+Time.deltaTime;
        }


         

        //control statements
        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x>-1)
        {
            track=-1;
            //rb.velocity.x = -5;
            rb.AddForce(-thrust,0,0, ForceMode.Acceleration);
            //StartCoroutine(stopslide());
            //pause = true;
          
         
            //transform.Translate(track,0,0);
            lane--; 
        }
        
        if(Input.GetKey(KeyCode.RightArrow)&& transform.position.x<1)
        {
            //track = 1;
            //transform.position =  new Vector3(track,0,0);
            //horizontalv = 5;
            //rb.AddForce(transform.right*horizontalv);
            rb.AddForce(thrust,0,0, ForceMode.Acceleration);
            //StartCoroutine(stopslide());
            //pause = true;
            // horizontalv = 100;
            
             
            lane++;
            
        }
      
        
        
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            checkjump();
           
            if(inair==false)
            {
           
                verticalv = 7;
                StartCoroutine(stopjump());
                
            }
          
        }

        if(GetComponent<Rigidbody>().transform.position.y <-2)
        {
             Destroy (gameObject); 
        }
        
    }
     private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag=="Obstacle")
       {
          Destroy (gameObject); 
            Instantiate(explosion, transform.position, Quaternion.identity);
            StartCoroutine(stopexplosion());
            StartCoroutine(scenechange());
          
       }
        if(other.gameObject.tag=="Orb")
       {
           Instantiate(explosion, transform.position, Quaternion.identity);
           StartCoroutine(stopexplosion());
        }

    }


    IEnumerator stopjump()
    {
    yield return new WaitForSeconds(0.5f);
    verticalv = -5;
    //StartCoroutine(downforce());
    
    }
    IEnumerator downforce()
    {
        yield return new WaitForSeconds(0.5f);
        verticalv = 0;
    }
    IEnumerator stopslide()
    {

        yield return new WaitForSeconds(0.2f);
        horizontalv = 0;
        pause = false;
    }

    private void checkjump()
    {
       if(GetComponent<Rigidbody>().transform.position.y>0.9f)
        {
         inair = true;
        }
        else{
         inair= false;
        }
    }

   
    IEnumerator stopexplosion()
    {
        yield return new WaitForSeconds(5f);
        
        Destroy(explosion.gameObject);
    }
      IEnumerator scenechange()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Game Over");

    }


}
