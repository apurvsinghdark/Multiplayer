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

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                Destroy(listings[index].gameObject);
                listings.RemoveAt(index);
            }
            else
            {
                RoomListing listing = Instantiate(_roomListing, _content);
                if (listing != null)
                    listing.SetRoomInfo(info);
            }
        }
    }
}
