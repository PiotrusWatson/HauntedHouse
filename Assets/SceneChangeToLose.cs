using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeToLose : MonoBehaviour {

    private bool isCollidedWithObj1 = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.name == "protagonist")
            isCollidedWithObj1 = true;

        if (isCollidedWithObj1) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }
    }

    public void OnCollisionExit(Collision collision) {
        if (collision.gameObject.name == "protagonist")
            isCollidedWithObj1 = false;
    }
}
