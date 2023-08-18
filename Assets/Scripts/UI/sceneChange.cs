using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{

    void Update()
    {
        // Check if the static variable becomes zero
        if (TrainSpawner.score == 10 && SceneManager.GetActiveScene().name != "level4")
        {
            TrainSpawner.collisions = 3;
            TrainSpawner.score = 0;
            if (SceneManager.GetActiveScene().name == "level1")
            {
            // Load the specified scene
            SceneManager.LoadScene("level2");
            }
            else if (SceneManager.GetActiveScene().name == "level2")
            {
            // Load the specified scene
            SceneManager.LoadScene("level3");
            }
            else if (SceneManager.GetActiveScene().name == "level3")
            {
            // Load the specified scene
            SceneManager.LoadScene("level4");
            }
        }
        if(TrainSpawner.collisions == 0){
            TrainSpawner.collisions = 3;
            TrainSpawner.score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }   
}
