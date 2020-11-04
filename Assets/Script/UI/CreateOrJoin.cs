using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoin : MonoBehaviour
{
    [SerializeField]
    private CreateRoom createRoom;
    [SerializeField]
    private RoomListingMenu roomListingMenu;

    private RoomsCanvas roomsCanvas;

    public void FirstInitialize(RoomsCanvas canvas)
    {
        roomsCanvas = canvas;
        createRoom.FirstIntialize(canvas);
        roomListingMenu.FirstInitialize(canvas);
    }
}
