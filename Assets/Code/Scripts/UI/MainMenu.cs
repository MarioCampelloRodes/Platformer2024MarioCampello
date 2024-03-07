using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startScene, continueScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Cerrando el juego");
    }
}
