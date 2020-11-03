using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector3 MovementLeft
    {
        get{
            return  new Vector3(-1,0,0);
        }
    }
    public Vector3 MovementRight
    {
        get{
            return  new Vector3(1,0,0);
        }
    }
}
