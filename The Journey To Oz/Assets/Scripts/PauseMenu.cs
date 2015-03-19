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
             GUILayout.BeginArea (new Rect((Screen.width/2)-50, (Screen.height/2), 100, 100), "<color=White><size=40>Paused</size></color>");
             //GUILayout.Label("Game is paused!");
             
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
    

