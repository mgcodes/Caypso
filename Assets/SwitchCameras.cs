using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{

    public Camera[] cameras;
    private int currentcam;

    public Camera red;
    public Camera blue;



    // Start is called before the first frame update
    void Start()
    {
        currentcam = 0;

        cameras[0] = blue;
        cameras[1] = red;


        if (cameras.Length>0)
         {
             cameras [0].gameObject.SetActive (true);
             Debug.Log ("Camera with name: " + cameras[0].name + "Blue");
         }
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.C))
         {
             currentcam++;
             Debug.Log ("C button has been pressed. Switching to the next camera");
             if (currentcam < cameras.Length)
             {
                 cameras[currentcam-1].gameObject.SetActive(false);
                 cameras[currentcam].gameObject.SetActive(true);
                 Debug.Log ("Camera with name: " + cameras[currentcam].name + ", is now enabled");
             }
             else
             {
                 cameras[currentcam-1].gameObject.SetActive(false);
                 currentcam = 0;
                 cameras[currentcam].gameObject.SetActive(true);
                 Debug.Log ("Camera with name: " + cameras [currentcam].name + ", is now enabled");
             }
         }
     
        
    }
}
