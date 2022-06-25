using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    [Header("Scenes")]
    [SerializeField] private int iSceneToLoad;
    [SerializeField] private string sSceneToLoad;
    public bool useIntegerToLoadScene = false;


    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        if(useIntegerToLoadScene)
        {
            SceneManager.LoadScene(iSceneToLoad);
            

        }
        else
        {
            SceneManager.LoadScene(sSceneToLoad);
        }
    }

}
