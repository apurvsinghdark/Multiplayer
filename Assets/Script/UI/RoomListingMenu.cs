using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;

    private List<RoomListing> listings = new List<RoomListing>();

    private RoomsCanvas roomsCanvas;

    public void FirstInitialize(RoomsCanvas canvas)
    {
        roomsCanvas = canvas;
    }

    public override void OnJoinedRoom()
    {
        roomsCanvas.CurrentRoom.Show();
        _content.DestroyChildren();
        listings.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            else
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index == -1)
                {
                    RoomListing _listing = Instantiate(_roomListing, _content);
                    if (_listing != null)
                    { 
                        _listing.SetRoomInfo(info);
                        listings.Add(_listing);
                    }
                }
                else
                {

                }
            }
        }
    }
}
