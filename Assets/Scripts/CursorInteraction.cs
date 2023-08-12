using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FinishSpookingEvent : UnityEvent<GameObject>{

}

//Could make more generic later???? if we need diff interactions oops
[RequireComponent(typeof(Spooker))]
[RequireComponent(typeof(AudioSource))]
public class CursorInteraction : MonoBehaviour
{
    public GameObject createdGameObject;

    Material originalMaterial;
    public Material hoverMaterial;
    public Material afterInteractionMaterial;
    public AudioClip[] explosions;
    
    Renderer[] childRenderer;

    bool isDone = false;
    

    Spooker spook;
    AudioSource audioSource;
    
    void MakeSomeNoise(){
        AudioClip pickedSplode = explosions[Random.Range(0, explosions.Length)];
        audioSource.clip = pickedSplode;
        audioSource.Play();
    }

    // Start is called before the first frame update
    void Start() {
        originalMaterial = GetComponent<Renderer>().materials[0];

        childRenderer = GetComponentsInChildren<Renderer>();
        audioSource = GetComponent<AudioSource>();
        spook = GetComponent<Spooker>();

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
            MakeSomeNoise();
            Instantiate(createdGameObject, transform.position, Quaternion.identity);
            spook.ToggleSpook(true);
            isDone = true;

            foreach (Renderer renderer in childRenderer) {
                if (afterInteractionMaterial != null) {
                    renderer.material = afterInteractionMaterial;
                }
            }
        }
    }
    public void CurrentHoveredGameObject(GameObject hoveredgameObject) {
        if (hoveredgameObject == gameObject && !isDone) {
            foreach (Renderer renderer in childRenderer) {
                if (hoverMaterial != null) {
                    renderer.material = hoverMaterial;
                }
            }
        } else if (!isDone) {
            foreach (Renderer renderer in childRenderer) {
                if (originalMaterial != null) {
                    renderer.material = originalMaterial;
                }
            }
        }
    }
}
