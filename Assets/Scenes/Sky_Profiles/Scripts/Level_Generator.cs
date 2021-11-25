using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Generator : MonoBehaviour
{
    public GameObject flat = null;
    public GameObject obstacke = null;
    private Transform startposition;
    private Vector3 endposition; 
    public GameObject player;
    
    private const float levelspawndist = 50;
    private Vector3 playerposition;


    // Start is called before the first frame update
    void Start()
    {   
       endposition = GameObject.Find("EndPosition").transform.position;
    
    }

     private void FixedUpdate()
     {
    
       if(Vector3.Distance(GameObject.Find("Player").transform.position, endposition)<levelspawndist)
        {

            spawnpart();
        
        }   
     }

    private void spawnpart()
    {
        Transform prevpart = spawnlevel(endposition);
        endposition =  prevpart.Find("EndPosition").transform.position;
    }


    private Transform spawnlevel(Vector3 spawnpos)
    {
        GameObject currentblock;
        currentblock = Instantiate(flat, spawnpos, Quaternion.identity);
        return currentblock.transform;

    }
}
