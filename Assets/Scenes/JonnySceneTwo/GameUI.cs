using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUIManager : VisualElement {
    VisualElement RoomButton1;
    VisualElement RoomButton2;
    VisualElement RoomButton3;
    VisualElement RoomButton4;

    public new class UxmlFactory : UxmlFactory<GameUIManager, UxmlTraits> { }
    public GameUIManager() {
        RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }
    void OnGeometryChange(GeometryChangedEvent evt) {
        // Camera Positions
        RoomButton1 = this.Q("btnRoom01");
        RoomButton1?.RegisterCallback<ClickEvent>(ev => ClickedRoomButton(1));
        RoomButton2 = this.Q("btnRoom02");
        RoomButton2?.RegisterCallback<ClickEvent>(ev => ClickedRoomButton(2));
        RoomButton3 = this.Q("btnRoom03");
        RoomButton3?.RegisterCallback<ClickEvent>(ev => ClickedRoomButton(3));
        RoomButton4 = this.Q("btnRoom04");
        RoomButton4?.RegisterCallback<ClickEvent>(ev => ClickedRoomButton(4));
    }
    void ClickedRoomButton(int RoomID) {
        Debug.Log("RoomID = " + RoomID);
    }
}