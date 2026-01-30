using UnityEngine;

public class InputPixels : MonoBehaviour
{
    internal GameObject[,] displayGrid;
    [SerializeField] GameObject[] inputPixels = new GameObject[7];

    private void Start()
    {
        displayGrid = PixelGridSpawner.Instance.displayGrid;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) inputPixels[0].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.A)) inputPixels[1].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.UpArrow)) inputPixels[2].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) inputPixels[3].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.RightArrow)) inputPixels[4].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.DownArrow)) inputPixels[5].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.S)) inputPixels[6].GetComponent<PixelState>().Switch();
    }
}
