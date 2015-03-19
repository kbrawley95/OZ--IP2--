using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

     public bool paused = false;
 
     void Update()
     {
         if(Input.GetButtonDown("PauseButton"))
             paused = togglePause();
     }
     
     void OnGUI()
     {
         if(paused)
         {
             GUILayout.BeginArea(new Rect(750, 300, 200, 200));
             GUILayout.Label("Game is paused!");
             GUILayout.EndArea();

            
         }
     }  
     
     bool togglePause()
     {
         if(Time.timeScale == 0f)
         {
             Time.timeScale = 1f;
             return(false);
         }
         else
         {
             Time.timeScale = 0f;
             return(true);    
         }
     }


    }
    

