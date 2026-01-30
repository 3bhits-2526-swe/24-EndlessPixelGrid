using TMPro;
using UnityEngine;

public class PixelGridSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pixelPrefab;
    [SerializeField] private float gap = 5;
    [SerializeField] private float yStartPos = 275;

    private void Awake()
    {
        gap = gap + 25;
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 10; j++)
                Instantiate(pixelPrefab, new Vector3(171 + i * gap, yStartPos + j * -gap, 0), Quaternion.identity, transform);
        }
    }
}
