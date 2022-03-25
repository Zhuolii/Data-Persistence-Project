using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static string playerName;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
 playerName = MenuHandler.username;
            DontDestroyOnLoad(gameObject);

    }

   
    void Awake()
    {
        
           
    }






}
