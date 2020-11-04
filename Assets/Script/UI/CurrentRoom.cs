using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoom : MonoBehaviour
{
    [SerializeField]
    private PlayerListMenu playerListMenu;
    [SerializeField]
    private LeaveRoomMenu leaveRoomMenu;

    private RoomsCanvas roomsCanvas;

    public void FirstInitialize(RoomsCanvas canvas)
    {
        roomsCanvas = canvas;
        playerListMenu.FirstInitialize(canvas);
        leaveRoomMenu.FirstInitialize(canvas);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
