using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomProperties : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private ExitGames.Client.Photon.Hashtable myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    private void SetCustomNumber()
    {
        System.Random rnd = new System.Random();
        int result = rnd.Next(0, 99);

        text.text = result.ToString();

        myCustomProperties["RandomNumber"] = result;
        //myCustomProperties.Remove("RandomNumber");
        PhotonNetwork.SetPlayerCustomProperties(myCustomProperties);
    }

    public void OnClickButton()
    {
        SetCustomNumber();
    }
}
