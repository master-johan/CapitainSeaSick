using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioClip menuSong;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic(menuSong);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGameScene()
    {
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadNextLevel();// use levelLoader to change scene
        //SceneManager.LoadScene(1);
    }
}
