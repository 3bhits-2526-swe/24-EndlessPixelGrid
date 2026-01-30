using UnityEngine;

public class PixelGridSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pixelPrefab;
    [SerializeField] private float gap = 5;
    [SerializeField] private float yStart = 5;

    private int columns = 7;
    private int rows = 10;

    private void Awake()
    {
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
                RectTransform prt = pixel.GetComponent<RectTransform>();

                float xPos = startX + (i * (cellWidth + gap));
                float yPos = startY - (j * (cellHeight + gap));

                prt.anchoredPosition = new Vector2(xPos, yPos);
            }
        }
    }
}