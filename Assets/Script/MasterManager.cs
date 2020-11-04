using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "Scriptables/MasterManger")]
public class MasterManager : ScriptableObjectSingleton<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings;

    public static GameSettings GameSettings { get { return Instance._gameSettings; } }

    private List<NetworkPrefeb> networkPrefebs = new List<NetworkPrefeb>();

    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        foreach(NetworkPrefeb networkPrefeb in Instance.networkPrefebs)
        {
            if (networkPrefeb.Prefeb == obj)
            {
                if (networkPrefeb.Path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkPrefeb.Path, position, rotation);
                    return result;
                }
                else
                {
                    Debug.LogError("Path is empty for gameobject name " + networkPrefeb.Prefeb);
                    return null;
                }
            }
        }
        
        return null;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void PopulateNetworkPrefeb()
    {
#if UNITY_EDITOR

        Instance.networkPrefebs.Clear();

        GameObject[] results = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < results.Length; i++)
        {
            if(results[i].GetComponent<PhotonView>() != null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                Instance.networkPrefebs.Add(new NetworkPrefeb(results[i], path));
            }
        }
#endif
    }
}
