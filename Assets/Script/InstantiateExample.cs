using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateExample : MonoBehaviourPun
{
    [SerializeField]
    private GameObject prefeb;

    private void Awake()
    {
        MasterManager.NetworkInstantiate(prefeb, transform.position, Quaternion.identity);
        //PhotonNetwork.Instantiate(prefeb.name, transform.position, Quaternion.identity);
    }
}
