using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManeger : MonoBehaviour
{
    // Start is called before the first frame update
    public static UiManeger Instance;
    [SerializeField] private Canvas homeCanvas;
    [SerializeField] private Canvas popCanvas;
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
        homeCanvas.enabled = false;
        popCanvas.enabled = false;
    }
    void Start()
    {
        homeCanvas.enabled=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play()
    {
      //  homeCanvas.enabled = false;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the next scene index
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if next scene index is within the bounds
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load!");
        }
         

    }
    public void gameOverScreaan()
    {
        popCanvas.enabled = true;   
    }
    public void reload()
    {
        audioManeger.Instance.playSound(soundName.click);
        SceneManager.LoadScene(0);
    }
    public void gameOver()
    {
        popCanvas.enabled = true;
    }
}
