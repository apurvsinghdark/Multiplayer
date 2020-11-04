using Photon.Pun;
using UnityEngine;

public class InputManager : MonoBehaviourPunCallbacks
{
    [PunRPC]
    public Vector3 MovementLeft
    {
        get
        {
            return new Vector3(-1, 0, 0);
        }
    }

    [PunRPC]
    public Vector3 MovementRight
    {
        get
        {
            return new Vector3(1, 0, 0);
        }
    }
}