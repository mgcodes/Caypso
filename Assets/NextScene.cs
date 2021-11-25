using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour

{
     protected static string currentscename; 

    public string SceneName1;
    public string SceneName2;

    public string SceneName3;
    

    private static int scenenum = 0;

    public Animator transition;

    public string Prev;

    
    public void scenechange1()
    {
        pausetime();
        SceneManager.LoadScene(SceneName1);
        scenenum = 1;
        
    }

    
    public void scenechange2()
    {
        StartCoroutine(pausetime());
        SceneManager.LoadScene(SceneName2);
        scenenum = 2;
        
    }
        public void scenechange3()
    {
        StartCoroutine(pausetime());
        SceneManager.LoadScene(SceneName3);
        scenenum = 3;
        
    }


    public void goback()
    {
        StartCoroutine(pausetime());
        SceneManager.LoadScene(Prev);
        
    }

    public void retry()
    {
        if(scenenum == 1)
        {
            scenechange1();
            
        }

        if(scenenum == 2)
        {
            scenechange2();
            

        }
    }

    public void quit()
    {
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
IEnumerator pausetime()
{
    transition.SetTrigger("Scenetrigger");
    yield return new WaitForSeconds(10f);
}
    
}
  

