using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoin createOrJoin;
    public CreateOrJoin CreateOrJoin { get { return createOrJoin; } }

    [SerializeField]
    private CurrentRoom currentRoom;
    public CurrentRoom CurrentRoom { get { return currentRoom; } }

    private void Awake()
    {
        FirstIntialize();
    }

    private void FirstIntialize()
    {
        createOrJoin.FirstInitialize(this);
        currentRoom.FirstInitialize(this);
    }
}
