using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public static int prevLevel;
    private bool next = false;
    private bool again = false;
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "levelCleared" && next)
            {
                if (prevLevel == 1)
                {
                    // Load the specified scene
                    SceneManager.LoadScene("level2");
                }
                else if (prevLevel == 2)
                {
                    // Load the specified scene
                    SceneManager.LoadScene("level3");
                }
                else if (prevLevel == 3)
                {
                    // Load the specified scene
                    SceneManager.LoadScene("level4");
                }
            }
        else if (SceneManager.GetActiveScene().name == "youLose-interval")
        {
            if (again && prevLevel == 1)
            {
                again = false;
                SceneManager.LoadScene("level1");
            }
            else if (again && prevLevel == 2)
            {
                again = false;
                SceneManager.LoadScene("level2");
            }
            else if (again && prevLevel == 3)
            {
                again = false;
                SceneManager.LoadScene("level3");
            }
            else if (again && prevLevel == 4)
            {
                again = false;
                SceneManager.LoadScene("level4");
            }
        }
        else if (TrainSpawner.score == 10 )
            {
                TrainSpawner.collisions = 5f;
                TrainSpawner.score = 0;
                if (SceneManager.GetActiveScene().name == "level1")
                {
                    prevLevel = 1;
                    // Load the specified scene
                    SceneManager.LoadScene("levelCleared");
                }
                else if (SceneManager.GetActiveScene().name == "level2")
                {
                    prevLevel = 2;
                    // Load the specified scene
                    SceneManager.LoadScene("levelCleared");
                }
                else if (SceneManager.GetActiveScene().name == "level3")
                {
                    prevLevel = 3;
                    // Load the specified scene
                    SceneManager.LoadScene("levelCleared");
                }
                else if (SceneManager.GetActiveScene().name == "level4")
                {
                    prevLevel = 4;
                    // Load the specified scene
                    SceneManager.LoadScene("GameOver");
                }
            }
        else if(TrainSpawner.collisions == 0)
        {
            TrainSpawner.collisions = 5;
            TrainSpawner.score = 0;
            if (SceneManager.GetActiveScene().name == "level1")
            {
                prevLevel = 1;
            }
            else if (SceneManager.GetActiveScene().name == "level2")
            {
                prevLevel = 2;
             }
            else if (SceneManager.GetActiveScene().name == "level3")
            {
                prevLevel = 3;

            }
            else if (SceneManager.GetActiveScene().name == "level4")
            {
                prevLevel = 4;
            }
            SceneManager.LoadScene("youLose-interval");
        }
    }
    public void setAgain()
    {
        again = true;
    }
    public void setNext()
    {
        next = true;
    }
}



    
        