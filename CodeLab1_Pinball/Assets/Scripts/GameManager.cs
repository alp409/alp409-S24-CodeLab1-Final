using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;

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
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            Debug.Log("Score Changed");
            if (score > HighScore)
            {
                HighScore = score;
            }
        }
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
        }
    }
    

    void Awake()
    {
        if (instance = null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    } // You're a singleton now, good job Game Manager! Gold star.

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
