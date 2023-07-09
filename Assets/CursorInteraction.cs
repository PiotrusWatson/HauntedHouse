using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FinishSpookingEvent : UnityEvent<GameObject>{

}
public class CursorInteraction : MonoBehaviour
{
    public GameObject createdGameObject;
    Material originalMaterial;
    public Material hoverMaterial;
    bool isDone = false;
    // Start is called before the first frame update
    void Start() {
        originalMaterial = GetComponent<Renderer>().materials[0];
    }

    // Update is called once per frame
    void Update() {       
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit, 100f)) {
            if (raycastHit.transform != null) {
                // Check for mouse hover
                CurrentHoveredGameObject(raycastHit.transform.gameObject);
                //Check for mouse click
                if (Input.GetMouseButtonDown(0)) {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
    }
    public void CurrentClickedGameObject(GameObject clickedgameObject) {
        if (clickedgameObject == gameObject && !isDone) {
            Debug.Log("you clicked " + clickedgameObject.name);

            Instantiate(createdGameObject, transform.position, Quaternion.identity);
            isDone = true;
        }
    }
    public void CurrentHoveredGameObject(GameObject hoveredgameObject) {
        Debug.Log("Material is: " + GetComponent<Renderer>().material);
        if (hoveredgameObject == gameObject && !isDone) {
            GetComponent<Renderer>().material = hoverMaterial;
        } else {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
}
