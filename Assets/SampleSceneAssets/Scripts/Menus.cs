using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    public void LoadLevel1()
    {
        //SceneManager.LoadScene("Level1");
        Debug.Log("Level 1 !");
    }

    public void LoadLevel2()
    {
        //SceneManager.LoadScene("Level2");
        Debug.Log("Level 2 !");
    }
    public void LoadLevel3()
    {
        //SceneManager.LoadScene("Level3");
        Debug.Log("Level 3 !");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit !");
    }
}
