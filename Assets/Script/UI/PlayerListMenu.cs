using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListing;

    private List<PlayerListing> listings = new List<PlayerListing>();
    private RoomsCanvas roomsCanvas;


    public override void OnEnable()
    {
        base.OnEnable();
        GetCurrentRoomPlayers();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < listings.Count; i++)
        {
            Destroy(listings[i].gameObject);
        }
        listings.Clear();
    }

    public void FirstInitialize(RoomsCanvas canvas)
    {
        roomsCanvas = canvas;
    }

    private void GetCurrentRoomPlayers()
    {
        foreach (KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    private void AddPlayerListing(Player player)
    {
        int index = listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            listings[index].SetPlayerInfo(player);
        }
        else
        {
            PlayerListing _listing = Instantiate(_playerListing, _content);
            if (_listing != null)
            {
                _listing.SetPlayerInfo(player);
                listings.Add(_listing);
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        /*layerListing _listing = Instantiate(_playerListing, _content);
        if (_listing != null)
            _listing.SetPlayerInfo(newPlayer);
            listings.Add(_listing);*/

        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = listings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(listings[index].gameObject);
            listings.RemoveAt(index);
        }
    }
}
