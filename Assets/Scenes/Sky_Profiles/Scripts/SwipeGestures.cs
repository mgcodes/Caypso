    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeGestures : MonoBehaviour
{
   protected bool swipeleft, swiperight, swipeup; 
   private Vector2 startTouch, swipeDelta;
   private bool isdragging = false;
    private int lane = 2;
    private float verticalv = -2;
    private int track;
    public float horizontalv;
    public float speed;
    private float maxspeed=50;
     private bool inair = false;
    private bool isgrounded = false;
    private Rigidbody  rb;
    private bool pause = false;
    public float thrust;      
     private float screenCenterX;
     
     protected static string currentscename; 
     public GameObject explosion;
     public Animator transition;

     
    private float startTime;

        
     


    
    private void Start()
    {
          rb = GetComponent<Rigidbody>();
          Touch firstTouch = Input.GetTouch(0);
          screenCenterX = Screen.width*0.5f;
            
          

    }


    private void Update()
    {
          GetComponent<Rigidbody>().velocity = new Vector3 (0,verticalv,speed);
        
        if(speed<maxspeed)
        {
            speed = speed+Time.deltaTime;
        }
       
        
 
            //KEYBOARD CONTROLS FOR TESTING
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

        //+++++++++++TOUCH CONTROLS++++++++++++++++++++++++++++++++++

        int i = 0;
		//loop over every touch found
        
		    while (i < Input.touchCount) {
			if (Input.GetTouch (i).position.x > Screen.width*0.5f && Input.GetTouch (i).position.y < Screen.height*0.5f ) {
				//move right
                if(transform.position.x<1)
                {
                     rb.AddForce(thrust,0,0, ForceMode.Acceleration);
                }
				
			}
			if (Input.GetTouch (i).position.x < Screen.width*0.5f &&  Input.GetTouch (i).position.y < Screen.height*0.5f) {
				//move left
                if(transform.position.x>-1)
                {
                    
				 rb.AddForce(-thrust,0,0, ForceMode.Acceleration);

                }
			}
            if(Input.GetTouch (i).position.y > Screen.height*0.5f){
                
            checkjump();
           
            if(inair==false)
            {
           
                verticalv = 7;
                StartCoroutine(stopjump());
                
            }
            }

			++i;

        
        }
        
         if(Input.touches.Length>0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }


        if(swipeDelta.magnitude>50)
        {
              float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x)<Mathf.Abs(y))
            {
                
                //up
                if(y>0)
                {
                    swipeup = true;
                }
            }

        }
          if(GetComponent<Rigidbody>().transform.position.y <-1)
        {
            StartCoroutine(scenechange());

        }
        if(!GetComponent<Rigidbody>().transform.hasChanged)
        {
            SceneManager.LoadScene("Game Over");
        }
      
    }

//=============================================================================


   private void Reset()
   {
       isdragging = false;
       startTouch = swipeDelta = Vector2.zero;
   }


    IEnumerator stopjump()
    {
    yield return new WaitForSeconds(0.5f);
    verticalv = -7;
    StartCoroutine(downforce());
    
    }
    IEnumerator downforce()
    {
        yield return new WaitForSeconds(0.5f);
        verticalv = -2;
    }

    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag=="Obstacle")
       {
        GetComponent<MeshRenderer>().enabled=false;
       // speed = 0;
       // Instantiate(explosion, transform.position, Quaternion.identity);
        //stopexplosion();
        //SceneManager.LoadScene("Game Over");
         StartCoroutine(scenechange());
                  
       
       }
        if(other.gameObject.tag=="Orb")
       {
           Instantiate(explosion, transform.position, Quaternion.identity);
           StartCoroutine(stopexplosion());
        }

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

    IEnumerator scenechange()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Game Over");

    }

        IEnumerator stopexplosion()
    {
        yield return new WaitForSeconds(5f);
        
        Destroy(explosion.gameObject);
    }

        


     

}
