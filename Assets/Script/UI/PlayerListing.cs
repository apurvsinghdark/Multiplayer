using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public Player Player { get; private set; }

    public void SetPlayerInfo (Player _player)
    {
        Player = _player;
        _text.text = Player.NickName;
    }
}
