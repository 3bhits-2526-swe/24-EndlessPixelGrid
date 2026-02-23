using UnityEngine;

private class PixelGridSpawner : MonoBehaviour
{
    public static PixelGridSpawner Instance { get; private set; }

    [SerializeField] private GameObject pixelPrefab;
    private float gap = 5;
    float yStart = 5;

    internal GameObject[,] displayGrid;

    private int columns = 7;
    private int rows = 10;

    private void Awake()
    {
        Instance = this;
        displayGrid = new GameObject[columns, rows];

        RectTransform rt = pixelPrefab.GetComponent<RectTransform>();
        float cellWidth = rt.rect.width;
        float cellHeight = rt.rect.height;

        float totalWidth = (columns * cellWidth) + ((columns - 1) * gap);
        float totalHeight = (rows * cellHeight) + ((rows - 1) * gap);

        float startX = (-totalWidth / 2f) + (cellWidth / 2f);
        float startY = yStart + (totalHeight / 2f) - (cellHeight / 2f);

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject pixel = Instantiate(pixelPrefab, transform);
                pixel.AddComponent<PixelState>();
                RectTransform prt = pixel.GetComponent<RectTransform>();

                float xPos = startX + (i * (cellWidth + gap));
                float yPos = startY - j * (cellHeight + gap));

                prt.anchoredPosition = new Vector2(xPos, yPos);
                displayGrid[i, j] = pixel;
            }
        }
    }
