using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

    // Play Button
    public void loadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


    // Quit Button
    public void Quit()
    {
        Application.Quit();
    }


    // To Be Developed
    public void LevelCreation(int sceneIndex)
    {

    }
}
