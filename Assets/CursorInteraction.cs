using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorInteraction : MonoBehaviour
{
    public GameObject CloneDYNAMMITE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f)) {
                if (raycastHit.transform != null) {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
    }
    public void CurrentClickedGameObject(GameObject gameObject) {
        if (gameObject.name == "ExplodeDesk") {
            Debug.Log("you clicked " + gameObject.name);

            Instantiate(CloneDYNAMMITE, transform.position, Quaternion.identity);
        }
    }
}
