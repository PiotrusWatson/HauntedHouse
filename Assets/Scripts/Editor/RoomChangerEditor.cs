using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RoomChangeUnderstander))]
public class RoomChangerEditor : Editor
{
    void OnSceneGui(){
        RoomChangeUnderstander changer = (RoomChangeUnderstander) target;
        Handles.color = Color.green;
    }
}
