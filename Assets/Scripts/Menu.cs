using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject myPanel;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            myPanel.SetActive(!myPanel.activeSelf);
            if(myPanel.activeSelf) {
                Time.timeScale = 0;
            } else {
                Time.timeScale = 1;
            }
        }
    }

    public void StartGame() {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene != null) {
            myPanel.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }

    public void OptionsMenu() {
        
    }

    public void NextLevel() {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene != null) {
            myPanel.SetActive(false);
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }

    public void PrevLevel() {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene != null) {
            SceneManager.LoadScene(currentScene.buildIndex - 1);
        }
    }

    public void Restart() {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene != null) {
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }

    public void Quit() {
        Application.Quit();
    }
}
