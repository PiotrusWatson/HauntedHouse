using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RoomChangeUnderstander))]
public class RoomChangerEditor : Editor
{
    void OnSceneGUI(){
        RoomChangeUnderstander changer = (RoomChangeUnderstander) target;
        Handles.color = Color.green;
        changer.RoomCentre = Handles.PositionHandle(changer.RoomCentre, Quaternion.identity);
        Handles.Label(changer.RoomCentre, "Centre of Room");
    }
}
