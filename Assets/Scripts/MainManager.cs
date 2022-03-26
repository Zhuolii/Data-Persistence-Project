using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text ScoreText2;
    public GameObject GameOverWindow;

    private bool m_Started = false;
    public static int m_Points;

    public static int highScore;

    private bool m_GameOver = false;

    public static string playerName = MenuHandler.username;







    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);

            }
        }
        ScoreText.text = $"{playerName} score : {m_Points}";


        LoadScore();
        m_Points = 0;
        Debug.Log("playername = " + playerName);



    }




    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                m_Points = 0;


                Debug.Log("highscore = " + highScore);
                m_GameOver = false;
            }
        }


        ScoreText.text = $"{MenuHandler.username} score : {m_Points}";

        if (m_Points > highScore == true && m_GameOver == true)
        {
            Debug.Log("points =" + m_Points);

            highScore = 0;
            highScore += m_Points;
            ScoreText2.text = $"{MenuHandler.username} Best score : {highScore}";

            Debug.Log("highscore if  = " + highScore);
            SaveScore();


        }




    }

    void AddPoint(int point)
    {
        m_Points += point;


    }


    public void GameOver()
    {

        m_GameOver = true;
        GameOverWindow.SetActive(true);








    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
        m_Points = 0;
        SaveScore();
    }
    public void ResetScore()
    {
        highScore = 0;
        m_Points = 0;
        Debug.Log(highScore);
        Debug.Log(m_Points);
        SaveScore();
        SceneManager.LoadScene(0);
        GameOverWindow.SetActive(false);

    }


    [System.Serializable]
    class PlayerHighScore
    {
        public string scoreText;
        public int score;
        public string name;
    }

    public void SaveScore()
    {
        Debug.Log("start save process");
        PlayerHighScore playerScore = new PlayerHighScore();
        playerScore.score = highScore;
        playerScore.name = playerName;

        playerScore.scoreText = $"{playerName} Best score : { highScore}";

        string json = JsonUtility.ToJson(playerScore);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("savedplayerscore.score = " + playerScore.score);
        Debug.Log("end save process");



    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("start load process");
            string json = File.ReadAllText(path);
            //fromjson<class>(json)

            PlayerHighScore playerScore = JsonUtility.FromJson<PlayerHighScore>(json);
            Debug.Log(" scoretext2 before load = " + ScoreText2.text);

            ScoreText2.text = playerScore.scoreText;
            Debug.Log(" scoretext2 after load = " + ScoreText2.text);
            Debug.Log(" highscore before load = " + highScore);
            highScore = playerScore.score;
            Debug.Log(" load highscore after load = " + highScore);
            Debug.Log("end load process");
        }
    }

}

