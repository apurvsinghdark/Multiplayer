using UnityEngine;
using Photon.Pun;

public class OwnerShip : MonoBehaviourPun
{
    private void OnMouseDown()
    {
        base.photonView.RequestOwnership();
    }
}
