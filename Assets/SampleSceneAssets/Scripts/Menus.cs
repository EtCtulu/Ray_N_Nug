using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Menus : MonoBehaviour
{
    public CinemachineVirtualCameraBase camMain;
    public CinemachineVirtualCameraBase camOption;
    public CinemachineVirtualCameraBase camGraphic;
    public CinemachineVirtualCameraBase camAudio;
    public CinemachineVirtualCameraBase camControl;
    public CinemachineVirtualCameraBase camManuel;
    public CinemachineVirtualCameraBase camLevel;
    public CinemachineVirtualCameraBase camCredit;

    private int levelToLoad = 1;

    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
        /*levelToLoad = 1;
        Debug.Log("Load level 1 ");*/
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(1);
        /*levelToLoad = 2;
        Debug.Log("Load level 2 !");*/
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(1);
        /*levelToLoad = 3;
        Debug.Log("Load level 3 !");*/
    }

    public void LaunchLevel()
    {
        if (levelToLoad == 1)
        {
            SceneManager.LoadScene(1);
        }
        else if (levelToLoad == 2)
        {
            SceneManager.LoadScene(2);
        }
        else if (levelToLoad == 3)
        {
            SceneManager.LoadScene("Level3");
        }
        else
        {
            Debug.Log("Failed to load");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit !");
    }

    public void ControlClassic()
    {
        Debug.Log("Control Classic");
    }

    public void ControlReverse()
    {
        Debug.Log("Control Reverse");
    }

    public void CameraMain()
    {
        camMain.m_Priority = 20;
        camLevel.m_Priority = 10;
        camOption.m_Priority = 10;
        camControl.m_Priority = 10;
        camGraphic.m_Priority = 10;
        camAudio.m_Priority = 10;
        camCredit.m_Priority = 10;
        camManuel.m_Priority = 10;
    }

    public void CameraLevel()
    {
        camMain.m_Priority = 10;
        camLevel.m_Priority = 20;
        camOption.m_Priority = 10;
        camControl.m_Priority = 10;
        camGraphic.m_Priority = 10;
        camAudio.m_Priority = 10;
        camCredit.m_Priority = 10;
        camManuel.m_Priority = 10;
    }

    public void CameraOption()
    {
        camMain.m_Priority = 10;
        camLevel.m_Priority = 10;
        camOption.m_Priority = 20;
        camControl.m_Priority = 10;
        camGraphic.m_Priority = 10;
        camAudio.m_Priority = 10;
        camCredit.m_Priority = 10;
        camManuel.m_Priority = 10;
    }

    public void CameraControl()
    {
        camMain.m_Priority = 10;
        camLevel.m_Priority = 10;
        camOption.m_Priority = 10;
        camControl.m_Priority = 20;
        camGraphic.m_Priority = 10;
        camAudio.m_Priority = 10;
        camCredit.m_Priority = 10;
        camManuel.m_Priority = 10;
    }

    public void CameraGraphic()
    {
        camMain.m_Priority = 10;
        camLevel.m_Priority = 10;
        camOption.m_Priority = 10;
        camControl.m_Priority = 10;
        camGraphic.m_Priority = 20;
        camAudio.m_Priority = 10;
        camCredit.m_Priority = 10;
        camManuel.m_Priority = 10;
    }

    public void CameraAudio()
    {
        camMain.m_Priority = 10;
        camLevel.m_Priority = 10;
        camOption.m_Priority = 10;
        camControl.m_Priority = 10;
        camGraphic.m_Priority = 10;
        camAudio.m_Priority = 20;
        camCredit.m_Priority = 10;
        camManuel.m_Priority = 10;
    }

    public void CameraCredit()
    {
        camMain.m_Priority = 10;
        camLevel.m_Priority = 10;
        camOption.m_Priority = 10;
        camControl.m_Priority = 10;
        camGraphic.m_Priority = 10;
        camAudio.m_Priority = 10;
        camCredit.m_Priority = 20;
        camManuel.m_Priority = 10;
    }

    public void CameraManuel()
    {
        camMain.m_Priority = 10;
        camLevel.m_Priority = 10;
        camOption.m_Priority = 10;
        camControl.m_Priority = 10;
        camGraphic.m_Priority = 10;
        camAudio.m_Priority = 10;
        camCredit.m_Priority = 10;
        camManuel.m_Priority = 20;
    }
}
