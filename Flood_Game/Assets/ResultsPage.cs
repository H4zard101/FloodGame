using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsPage : MonoBehaviour
{

    // Play Button
    public void PlayAgain(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


    // Quit Button
    public void Quit()
    {
        Application.Quit();
    }
}
