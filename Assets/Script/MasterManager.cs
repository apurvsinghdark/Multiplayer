using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "Scriptables/MasterManger")]
public class MasterManager : ScriptableObjectSingleton<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings;

    public static GameSettings GameSettings { get { return Instance._gameSettings; } }
}
