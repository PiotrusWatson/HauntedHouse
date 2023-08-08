using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveOnUp : MonoBehaviour
{
    public Image thingToCheckVisibilityOn;
    public float speed;
    public float yPointToStopOn;
    GameObject skipButton;
    // Start is called before the first frame update
    void Start()
    {
        skipButton = GameObject.Find("Skip");
    }

    // Update is called once per frame
    void Update()
    {
        if (thingToCheckVisibilityOn.rectTransform.position.y < yPointToStopOn){
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else if (skipButton){
            skipButton.SetActive(false);
        }
        
    }

   public bool isVisible(Image image){
    Ray ray = Camera.main.ScreenPointToRay(image.rectTransform.position);
    return Physics.Raycast(ray);
   }
 
}
