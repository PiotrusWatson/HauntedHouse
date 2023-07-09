using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FinishSpookingEvent : UnityEvent<GameObject>{

}

//Could make more generic later???? if we need diff interactions oops
[RequireComponent(typeof(Spooker))]
public class CursorInteraction : MonoBehaviour
{
    public GameObject CloneDYNAMMITE;
    bool isDone = false;
    Spooker spook;
    // Start is called before the first frame update
    void Start()
    {
        spook = GetComponent<Spooker>();
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
    public void CurrentClickedGameObject(GameObject clickedgameObject) {
        if (clickedgameObject == gameObject && !isDone) {
            Debug.Log("you clicked " + clickedgameObject.name);
            
            Instantiate(CloneDYNAMMITE, transform.position, Quaternion.identity);
            spook.ToggleSpook(true);
            isDone = true;
        }
    }
}
