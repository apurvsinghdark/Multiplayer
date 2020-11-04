using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerListMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListing;
    [SerializeField]
    private TextMeshProUGUI readyText;

    private List<PlayerListing> listings = new List<PlayerListing>();
    private RoomsCanvas roomsCanvas;
    private bool ready = false;


    public override void OnEnable()
    {
        base.OnEnable();

        SetReadyUp(false);
        GetCurrentRoomPlayers();
    }

    private void SetReadyUp(bool state)
    {
        ready = state;
        if (ready)
            readyText.text = "R";
        else
            readyText.text = "N";
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
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;

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

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        roomsCanvas.CurrentRoom.LeaveRoomMenu.Onclick_LeaveRoom();
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
    
    public void OnClick_StartGame()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < listings.Count; i++)
            {
                if (listings[i].Player != PhotonNetwork.LocalPlayer)
                {
                    if (!listings[i].Ready)
                        return;
                }
            }
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }
    }

    public void Onclick_ReadyUp()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            SetReadyUp(!ready);
            base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, ready);
        }
    }

    [PunRPC]
    private void RPC_ChangeReadyState(Player player, bool ready)
    {
        int index = listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            listings[index].Ready = ready;
        }
    }
}
