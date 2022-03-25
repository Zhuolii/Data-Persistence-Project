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
        Debug.Log("username scene value :" + MenuHandler.username);
        Debug.Log("highscore scene value :" + MainManager.highScore);
        Debug.Log("points scene value :" + MainManager.m_Points);
        if (MainManager.m_Points == MainManager.highScore)
        {
            HighScoreText.text = $" {MenuHandler.username}: {MainManager.highScore} ";
            //SaveHighScore();
            Debug.Log("if works ");
            
        }  //LoadHighScore();







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

    class HighScoreSave
    {
        public string highScoreText;
        public int score;
    }

    public void SaveHighScore()
    {
        HighScoreSave newHighScore = new HighScoreSave();
        newHighScore.score = MainManager.highScore;
        newHighScore.highScoreText = $"{MainManager.playerName} : {newHighScore.score} ";

        string json = JsonUtility.ToJson(newHighScore);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("savednewHighScore = " + newHighScore.score);

    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            //fromjson<class>(json)

            HighScoreSave newHighScore = JsonUtility.FromJson<HighScoreSave>(json);

            //HighScore.HighScoreText.text = newHighScore.highScoreText;
            MainManager.highScore = newHighScore.score;
            Debug.Log(" load highscore = " + MainManager.highScore);
        }
    }
}
