using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class RadiusDisplayer : MonoBehaviour {
    [Range(0,50)]
    public int segments = 50;
    [Range(0,5)]
    public float xradius = 5;
    [Range(0,5)]
    public float yradius = 5;
    LineRenderer line;
    Color savedStartColor;
    Color savedEndColor;

    void Start ()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = (segments + 1);
        line.useWorldSpace = false;
        savedStartColor = line.startColor;
        savedEndColor = line.endColor;
        CreatePoints ();
        ToggleVisibility(false);

    }

    public void ToggleVisibility(bool isVisible){
        if (isVisible){
            line.startColor = savedStartColor;
            line.endColor = savedEndColor;
            line.useWorldSpace = false;
        }
        else {
            line.startColor = Color.clear;
            line.endColor = Color.clear;
            //lmao why does turning it off and on again make it invisible this is so funny
            line.useWorldSpace = false;
            line.useWorldSpace = true;
        }



    }

    void CreatePoints ()
    {
        float x;
        float y;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition (i,new Vector3(x,0,y) );

            angle += (360f / segments);
        }
    }
}