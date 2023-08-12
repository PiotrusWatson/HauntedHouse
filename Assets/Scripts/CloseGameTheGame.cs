using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGameTheGame : MonoBehaviour {
    public bool endOfAnimation;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (endOfAnimation) {
            ChangeScene();
        }
    }

    public void ChangeScene() {
        Debug.Log("Game should quit now");
        Application.Quit();
    }
}
