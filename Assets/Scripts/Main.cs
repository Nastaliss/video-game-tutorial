using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    static Main _instance;
    public static Main Instance
        
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Main>();
            }
            return _instance;
        }
    }

    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager.Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {

    }

   
}

