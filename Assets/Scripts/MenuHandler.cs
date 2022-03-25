using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuHandler : MonoBehaviour
{
 
    

    // Update is called once per frame
   

    public void StartGame()
    {
        SceneManager.LoadScene(0);
        
    }
    public void ExitGame()
    {
        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
    public void LoadHighScore()
    {
        SceneManager.LoadScene(2);
    }

 public InputField usernameInput;
     public static string username;
   
 
     void Start() {
        
               
     }
 
     public void SaveUsername(string newName) {
         username = newName;
     }
      void Update()
         {
             
              
         }
     
}
