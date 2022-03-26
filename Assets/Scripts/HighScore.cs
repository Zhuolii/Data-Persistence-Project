using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class HighScore : MonoBehaviour
{
    public Text HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("playername scene value :" + MainManager.playerName);
        Debug.Log("highscore scene value :" + MainManager.highScore);
        Debug.Log("points scene value :" + MainManager.m_Points);
        if (MainManager.m_Points == MainManager.highScore)
        {
             Debug.Log("playername scene value before:" + MainManager.playerName);
            MainManager.playerName = MenuHandler.username;
              Debug.Log("playername scene value after :" + MainManager.playerName);

            HighScoreText.text = $" {MainManager.playerName}: {MainManager.highScore} ";
         
             Debug.Log("saved higher score:" + HighScoreText.text );
          
            Debug.Log("if works ");
           
            Debug.Log("load higher score:" + HighScoreText.text );
       SaveScore1();
            
        }  
        //LoadHighScore();
         Debug.Log("load basic:" + HighScoreText.text );
         LoadScore1();
       







    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void SeeHighScore()
    {
        SceneManager.LoadScene(2);
    }

    [System.Serializable]
    class PlayerHighScore
    {
        public string scoreText;
        public int score;
        public string name;
    }

    public void SaveScore1()
    {
        Debug.Log("start save process");
        PlayerHighScore playerScore = new PlayerHighScore();
        playerScore.score = MainManager.highScore;
        playerScore.name =  MainManager.playerName;
        Debug.Log("MainManager.highScore =");
         Debug.Log(MainManager.highScore);
        
        Debug.Log("MainManager.playerName =" );
        Debug.Log( MainManager.playerName);

        playerScore.scoreText = $"{ MainManager.playerName} Best score : {  MainManager.highScore}";

        string json = JsonUtility.ToJson( playerScore);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("savedplayerscore.score = " + playerScore.scoreText);
        Debug.Log("end save process");



    }
    public void LoadScore1()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("start load process");
            string json = File.ReadAllText(path);
            //fromjson<class>(json)

            PlayerHighScore playerScore = JsonUtility.FromJson<PlayerHighScore>(json);
             Debug.Log(" scoretext2 before load = " + HighScoreText.text);

            HighScoreText.text = playerScore.scoreText;
             Debug.Log(" scoretext2 after load = " + HighScoreText.text);
            Debug.Log(" highscore before load = " + MainManager.highScore);
            MainManager.highScore = playerScore.score;
            Debug.Log(" load highscore after load = " + MainManager.highScore);
              Debug.Log("end load process");
        }
    }
}
