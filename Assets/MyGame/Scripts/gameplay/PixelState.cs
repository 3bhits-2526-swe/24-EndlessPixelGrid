public class PixelState : MonoBehaviour
{
    internal bool isOn = false;

    internal void UpdatePixel()
    {
        if (isOn) GetComponent<Image>().color = Color.white
        else GetComponent<Image>().color = Color.black;
    }
}