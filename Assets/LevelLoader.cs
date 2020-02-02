using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }



    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "Menu")
        {
            Debug.Log("Menu is selected");
            LoadLevel();
        }
    }

    public void LoadLevel ()
    {
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress /0.9f);
            Debug.Log(progress);

            yield return null;
        }

        if(operation.isDone)
        {
            _anim.SetTrigger("fadeOut");
        }
    }
}
