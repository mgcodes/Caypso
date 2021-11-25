using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour
{
    private static int count;

    public Text displaycount;

    public Text displayhighscore;
    public Text displaycurrentscore;

    public Text display_iceorbs;
      public Text display_fireorbs;
 

    private static int highscore;
    private static int currentscore;

    private static int iceorbs;
    private static int fireorbs;
  

    public GameObject orb;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        count = int.Parse(displaycount.text);
      
    }

    // Update is called once per frame
    void Update()
    {
        
        if(count >highscore)
          {
            highscore = count;
          }
        displayhighscore.text = highscore.ToString();
        displaycurrentscore.text = currentscore.ToString();
        display_iceorbs .text = iceorbs.ToString();
         display_fireorbs .text = fireorbs.ToString();
        
       

    }

      private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag=="Orb")
       {
        
          count ++;
          displaycount.text = count.ToString();
          Destroy(other.gameObject);
          currentscore = count;        
       }

       if(other.gameObject.name == "Ice Orb(Clone)")
       {
         iceorbs ++;

       }
        
      if(other.gameObject.name == "Fire Orb(Clone)")
       {
         fireorbs ++;

       }


    }


}   
