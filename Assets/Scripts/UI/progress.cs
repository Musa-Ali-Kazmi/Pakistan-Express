using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progress : MonoBehaviour
{
    
    public Image progressBar;

    float curProgress, maxProgress =10;

    // Start is called before the first frame update
    void Start()
    {
        curProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        curProgress = TrainSpawner.score;
        progressBar.fillAmount = curProgress / maxProgress;
    }
}
