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
        if (Input.GetKeyDown(KeyCode.W)) inputPixels[0].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.A)) inputPixels[1].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.UpArrow)) inputPixels[2].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) inputPixels[3].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.RightArrow)) inputPixels[4].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.DownArrow)) inputPixels[5].GetComponent<PixelState>().Switch();
        if (Input.GetKeyDown(KeyCode.S)) inputPixels[6].GetComponent<PixelState>().Switch();
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
                bool valueBelow = displayGrid[i, j].GetComponent<PixelState>().isOn;
                displayGrid[i, j - 1].GetComponent<PixelState>().SwitchTo(valueBelow);
            }
        }

        for (int i = 0; i < cols; i++)
        {
            PixelState inputState = inputPixels[i].GetComponent<PixelState>();

            displayGrid[i, rows - 1].GetComponent<PixelState>().SwitchTo(inputState.isOn);
            inputState.Disable();
        }
    }
}