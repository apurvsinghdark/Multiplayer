using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateExample : MonoBehaviour
{
    [SerializeField]
    private GameObject prefeb;

    private void Awake()
    {
        MasterManager.NetworkInstantiate(prefeb, transform.position, Quaternion.identity);
    }
}
