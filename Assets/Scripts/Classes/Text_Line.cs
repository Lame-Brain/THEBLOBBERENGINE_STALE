using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Line : MonoBehaviour
{
    public void Line_Clicked_On()
    {
        Debug.Log(""+transform.GetSiblingIndex());
    }
}
