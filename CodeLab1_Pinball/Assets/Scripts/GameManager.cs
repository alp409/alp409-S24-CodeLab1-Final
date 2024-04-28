using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    private int highScore = 0;
    private const string KEY_HIGH_SCORE = "High Score";

    private const string DATA_DIR = "/Data/";
    private const string DATA_HS_FILE = "hs.txt";
    private string DATA_FULL_HS_FILE_PATH;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public AudioClip ambiance;
    
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
                // if the value is a single digit, add "0" string in front to make it look pretty
                if (value <= 9)
                {
                    scoreText.text = "0" + value.ToString();
                }
                else
                {
                    scoreText.text = value.ToString();
                }
            //scoreText.text = value.ToString();
            // Debug.Log("Score Changed");
            if (score > HighScore)
            {
                HighScore = score;
            }
        }
    }
    public void IncrementScore(float baseScore, float modifier)
    {
        int modifiedScore = Mathf.RoundToInt(baseScore * modifier);

        // 
        Score += modifiedScore;
    }
    
    int HighScore
    {
        get
        {
            if (File.Exists(DATA_FULL_HS_FILE_PATH))
            {
                string fileContents = File.ReadAllText(DATA_FULL_HS_FILE_PATH);
                highScore = int.Parse(fileContents);
            }
            return highScore;
        }
        set
        {
            highScore = value;
            Debug.Log("New High Score!");
            string fileContent = "" + highScore;

            if (!Directory.Exists(Application.dataPath + DATA_DIR))
            {
                Directory.CreateDirectory(Application.dataPath + DATA_DIR);
            }
            File.WriteAllText(DATA_FULL_HS_FILE_PATH, fileContent);
            
            highScoreText.text = HighScore.ToString(); 
        }
    }
    

    void Awake()
    {   // You're a singleton now, good job Game Manager! Gold star.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        if (ambiance != null)
        {
            AudioSource.PlayClipAtPoint(ambiance, transform.position); // TODO: make this loop?
        }
    } 

    void Start()
    {
        DATA_FULL_HS_FILE_PATH = Application.dataPath + DATA_DIR + DATA_HS_FILE;
        Debug.Log(HighScore);
        highScoreText.text = HighScore.ToString(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score = 0;
            scoreText.text = "00";
        }
    }
}
