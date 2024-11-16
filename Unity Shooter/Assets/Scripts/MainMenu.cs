using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public GameObject musicPlayer;

    private void Start() {
        DontDestroyOnLoad(musicPlayer);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene($"Game");
        }
    }
}
