using UnityEngine;

/// <summary>
/// Resizes a UI element with a RectTransform to respect the safe areas of the current device.
/// This is particularly useful on an iPhone X, where we have to avoid the notch and the screen
/// corners.
/// 
/// The easiest way to use it is to create a root Canvas object, attach this script to a game object called "SafeAreaContainer"
/// that is the child of the root canvas, and then layout the UI elements within the SafeAreaContainer, which
/// will adjust size appropriately for the current device./// </summary>
public class PinToSafeArea : MonoBehaviour
{

    RectTransform Panel;
    Rect LastSafeArea = new Rect(0, 0, 0, 0);

    void Awake()
    {
        Panel = GetComponent<RectTransform>();
        Refresh();
    }

    void Update()
    {
        Refresh();
    }

    void Refresh()
    {
        Rect safeArea = GetSafeArea();

        if (safeArea != LastSafeArea)
            ApplySafeArea(safeArea);
    }

    Rect GetSafeArea()
    {
        return Screen.safeArea;
    }

    void ApplySafeArea(Rect r)
    {
        LastSafeArea = r;

        // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
        Vector2 anchorMin = r.position;
        Vector2 anchorMax = r.position + r.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        Panel.anchorMin = anchorMin;
        Panel.anchorMax = anchorMax;

        Debug.LogFormat("New safe area applied to {0}: x={1}, y={2}, w={3}, h={4} on full extents w={5}, h={6}",
            name, r.x, r.y, r.width, r.height, Screen.width, Screen.height);
    }
}