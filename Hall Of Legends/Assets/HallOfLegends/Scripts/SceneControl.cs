using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    GameManager gameManager;
    Trigger trigger;
    public static SceneControl Instance;

    private string levelToLoad;
    public bool autoLoad;
    public float autoLoadWait = 3f;

    /// <summary>
    /// The empathy point of the player.
    /// </summary>
    [HideInInspector]public int empathyCount;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        if (autoLoad == true)
        {
            StartCoroutine(AutoLoad());
        }

        gameManager = GameObject.FindObjectOfType<GameManager>();
        trigger = GameObject.FindObjectOfType<Trigger>();
    }

    IEnumerator AutoLoad()
    {
        yield return new WaitForSeconds(autoLoadWait);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void FadeToLevel (string leveName)
    {
        levelToLoad = leveName;

        SceneManager.LoadScene(levelToLoad);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        gameManager.ResetPos();
        trigger.ResetPos();
        Application.Quit();
    }
}
