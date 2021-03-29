using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public Material[] colorMats;
    public Color levelColor;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Material cm in colorMats)
            cm.color = levelColor;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("EditorOnly")) go.SetActive(false); 
    }
}
