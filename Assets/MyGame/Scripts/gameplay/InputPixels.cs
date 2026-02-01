using UnityEngine;

public class InputPixels : MonoBehaviour
{
    private GameObject[,] displayGrid;
    private GameObject[] inputPixels = new GameObject[7];

    private void Start()
    {
        displayGrid = PixelGridSpawner.Instance.displayGrid;
        PixelState[] inputPixelsPixelStates = GetComponentsInChildren<PixelState>();
        for (int i = 0; i < inputPixelsPixelStates.Length; i++)
            inputPixels[i] = inputPixelsPixelStates[i].gameObject;
    }

    private void Update()
    {
        HandleInput();
        EnterInputs();
    }

    private void HandleInput()
    {
        bool changed = false;
        if (Input.GetKeyDown(KeyCode.W)) { inputPixels[0].GetComponent<PixelState>().isOn = !inputPixels[0].GetComponent<PixelState>().isOn; changed = true; }
        if (Input.GetKeyDown(KeyCode.A)) { inputPixels[1].GetComponent<PixelState>().isOn = !inputPixels[1].GetComponent<PixelState>().isOn; changed = true; }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { inputPixels[2].GetComponent<PixelState>().isOn = !inputPixels[2].GetComponent<PixelState>().isOn; changed = true; }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { inputPixels[3].GetComponent<PixelState>().isOn = !inputPixels[3].GetComponent<PixelState>().isOn; changed = true; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { inputPixels[4].GetComponent<PixelState>().isOn = !inputPixels[4].GetComponent<PixelState>().isOn; changed = true; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { inputPixels[5].GetComponent<PixelState>().isOn = !inputPixels[5].GetComponent<PixelState>().isOn; changed = true; }
        if (Input.GetKeyDown(KeyCode.S)) { inputPixels[6].GetComponent<PixelState>().isOn = !inputPixels[6].GetComponent<PixelState>().isOn; changed = true; }

        if (changed) RenderInputLine();
    }

    private void EnterInputs()
    {
        if (Input.GetKeyDown(KeyCode.D))
            PushArray();
    }

    public void PushArray()
    {
        int cols = displayGrid.GetLength(0);
        int rows = displayGrid.GetLength(1);

        for (int j = 1; j < rows; j++)
        {
            for (int i = 0; i < cols; i++)
            {
                displayGrid[i, j - 1].GetComponent<PixelState>().isOn = displayGrid[i, j].GetComponent<PixelState>().isOn;
            }
        }

        for (int i = 0; i < cols; i++)
        {
            displayGrid[i, rows - 1].GetComponent<PixelState>().isOn = inputPixels[i].GetComponent<PixelState>().isOn;
            inputPixels[i].GetComponent<PixelState>().isOn = false;
        }

        RenderGrid();
        RenderInputLine();
    }

    private void RenderGrid()
    {
        foreach (GameObject go in displayGrid)
        {
            go.GetComponent<PixelState>().UpdatePixel();
        }
    }

    private void RenderInputLine()
    {
        foreach (GameObject go in inputPixels)
        {
            go.GetComponent<PixelState>().UpdatePixel();
        }
    }
}