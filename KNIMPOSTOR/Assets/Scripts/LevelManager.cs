using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float sceneLoadDelay = 5f; 
    ScooreKeeper scooreKeeper; 

    void Awake() 
    {
        scooreKeeper = FindObjectOfType<ScooreKeeper>(); 
    }
    public void LoadGame()
    {
        scooreKeeper.ResetScore(); 
         StartCoroutine(WaitAndLoad("Game", sceneLoadDelay ));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("Finish", sceneLoadDelay ));
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); 
    }



    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName); 
    }

}
