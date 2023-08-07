using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public bool endOfAnimation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {

        if (endOfAnimation ) {
            //ChangeScene();
        }
    }

    public void ChangeScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void BackToMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ToCredits(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }
}
