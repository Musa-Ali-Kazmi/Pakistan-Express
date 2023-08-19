using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange2 : MonoBehaviour
{
    private bool start;
    private bool continues;
    private bool BackToMenu;

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            start = false; 
            SceneManager.LoadScene("instructions");
        }
        else if(continues){
            continues = false;
            SceneManager.LoadScene("level1");
        }
        else if (BackToMenu)
        {
            BackToMenu = false;
            SceneManager.LoadScene("Menu");
        }
        
    }
    public void setStart()
    {
        start = true;
    }
    public void setContinues()
    {
        continues = true;
    }
    public void setBackToMenu()
    {
        BackToMenu = true;
    }
}
