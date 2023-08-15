using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    
    public Text text;
    public Text text2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ""+TrainSpawner.score;
        text2.text = ""+TrainSpawner.collisions;// Collions counter
    }
}
