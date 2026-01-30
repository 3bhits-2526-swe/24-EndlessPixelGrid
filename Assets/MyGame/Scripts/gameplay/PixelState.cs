using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class PixelState : MonoBehaviour
{
    internal bool isOn = false;

    internal void Enable()
    {
        isOn = true;
        UpdatePixel();
    }
    internal void Disable()
    {
        isOn = false;
        UpdatePixel();
    }
    internal void Switch()
    {
        isOn = !isOn;
        UpdatePixel();
    }

    private void UpdatePixel()
    {
        if (isOn) GetComponent<Image>().color = UnityEngine.Color.white;
        else GetComponent<Image>().color = UnityEngine.Color.black;
    }
}
