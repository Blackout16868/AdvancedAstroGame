using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueMenu : MonoBehaviour
{
    [SerializeField] GameObject continueUi;
    void Start()
    {
         continueUi.SetActive(false);
    }

    private void Update() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void nextLevel(){
        Time.timeScale = 1f;
         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }


    public void continueLevel(){
        Time.timeScale = 1f;
         continueUi.SetActive(false);               
         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
    }
}