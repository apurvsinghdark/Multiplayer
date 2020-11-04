using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomsCanvas roomsCanvas;

    public void FirstInitialize(RoomsCanvas canvas)
    {
        roomsCanvas = canvas;
    }

    public void Onclick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        roomsCanvas.CurrentRoom.Hide();
    }
}
