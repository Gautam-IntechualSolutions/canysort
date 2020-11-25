using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int ScoreCounter;
    public float speed;

    public int CandyPlatform;
    // Start is called before the first frame update
    void Start()
    {
        speed = 200;
        ScoreCounter = 0;
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


}