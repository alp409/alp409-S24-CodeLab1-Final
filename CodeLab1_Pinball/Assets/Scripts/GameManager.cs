using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
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
    } // You're a singleton now, good job Game Manager.

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
