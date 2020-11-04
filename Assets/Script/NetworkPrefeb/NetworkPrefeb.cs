using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

[System.Serializable]
public class NetworkPrefeb
{
    public GameObject Prefeb;
    public string Path;

    public NetworkPrefeb(GameObject obj, string path)
    {
        Prefeb = obj;
        Path = ReturnPrefebPathModified(path);
    }

    private string ReturnPrefebPathModified(string path)
    {
        int extensionLength = System.IO.Path.GetExtension(path).Length;
        int additionLength = 10;
        int startIndex = path.ToLower().IndexOf("resources");

        if (startIndex == -1)
            return string.Empty;
        else
            return path.Substring(startIndex + additionLength, path.Length - (additionLength + startIndex + extensionLength));
    }
}
