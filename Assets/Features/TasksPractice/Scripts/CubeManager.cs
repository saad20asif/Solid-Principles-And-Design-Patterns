using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Threading.Tasks;
using System.Collections;

public class BuildingGenerator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Vector3Int buildingDimensions = new Vector3Int(10, 20, 10); // Width, Height, Depth
    [SerializeField] private float spacing = 1.1f;
    [SerializeField] private float animationHeight = 2f;
    [SerializeField] private float animationDuration = 3f;
    [SerializeField] private int batchSize = 500;

    [Header("Materials")]
    [SerializeField] private Material[] buildingMaterials;

    private List<GameObject> currentCubes = new List<GameObject>();
    private bool isAnimating;
    [SerializeField] private bool _useTask = true;

    private void Start()
    {
        if (_useTask)
            GenerateBuildingUsingTask();
        else
            GenerateBuildingUsingCo();
    }

    [Button("Generate Building")]
    private async void GenerateBuildingUsingTask()
    {
        // Destroy previous building
        ClearCurrentBuilding();

        // Start async generation
        await GenerateBuildingAsync();
    }
    private void GenerateBuildingUsingCo()
    {
        // Destroy previous building
        ClearCurrentBuilding();

        // Start co generation
        StartCoroutine(GenerateBuildingCo());
    }

    private async Task GenerateBuildingAsync()
    {
        Vector3 startPosition = transform.position;
        int cubeCount = 0;

        // Calculate center offset for proper building centering
        Vector3 sizeOffset = new Vector3(
            (buildingDimensions.x - 1) * spacing * 0.5f,
            0,
            (buildingDimensions.z - 1) * spacing * 0.5f
        );

        for (int y = 0; y < buildingDimensions.y; y++)
        {
            for (int x = 0; x < buildingDimensions.x; x++)
            {
                for (int z = 0; z < buildingDimensions.z; z++)
                {
                    // Create grid pattern with empty spaces
                    if (x > 0 && x < buildingDimensions.x - 1 &&
                        z > 0 && z < buildingDimensions.z - 1 &&
                        y % 4 != 0) continue;

                    Vector3 spawnPosition = new Vector3(
                        x * spacing,
                        y * spacing,
                        z * spacing
                    ) + startPosition - sizeOffset;

                    CreateCube(spawnPosition, y);
                    cubeCount++;

                    // Batch creation with async delay
                    if (cubeCount % batchSize == 0)
                    {
                        await Task.Yield();
                    }
                }
            }
        }

        StartInfiniteAnimation();
    }
    private IEnumerator GenerateBuildingCo()
    {
        Vector3 startPosition = transform.position;
        int cubeCount = 0;

        // Calculate center offset for proper building centering
        Vector3 sizeOffset = new Vector3(
            (buildingDimensions.x - 1) * spacing * 0.5f,
            0,
            (buildingDimensions.z - 1) * spacing * 0.5f
        );

        for (int y = 0; y < buildingDimensions.y; y++)
        {
            for (int x = 0; x < buildingDimensions.x; x++)
            {
                for (int z = 0; z < buildingDimensions.z; z++)
                {
                    // Create grid pattern with empty spaces
                    if (x > 0 && x < buildingDimensions.x - 1 &&
                        z > 0 && z < buildingDimensions.z - 1 &&
                        y % 4 != 0) continue;

                    Vector3 spawnPosition = new Vector3(
                        x * spacing,
                        y * spacing,
                        z * spacing
                    ) + startPosition - sizeOffset;

                    CreateCube(spawnPosition, y);
                    cubeCount++;

                    // Batch creation with async delay
                    if (cubeCount % batchSize == 0)
                    {
                        yield return null;
                    }
                }
            }
        }

        StartInfiniteAnimation();
        yield return null;
    }
    private void CreateCube(Vector3 position, int heightLevel)
    {
        GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity, transform);
        cube.name = $"BuildingCube_{heightLevel}";
        cube.SetActive(true);

        // Assign random material from array
        if (buildingMaterials.Length > 0)
        {
            Renderer renderer = cube.GetComponent<Renderer>();
            renderer.material = buildingMaterials[heightLevel % buildingMaterials.Length];
        }

        currentCubes.Add(cube);
    }

    private void StartInfiniteAnimation()
    {
        foreach (GameObject cube in currentCubes)
        {
            // Infinite up/down animation with yoyo effect
            cube.transform.DOMoveY(cube.transform.position.y + animationHeight, animationDuration)
                .SetEase(Ease.InOutQuad)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }

    private void ClearCurrentBuilding()
    {
        // Stop all animations first
        DOTween.KillAll();

        // Destroy all cubes
        foreach (GameObject cube in currentCubes)
        {
            if (cube != null) Destroy(cube);
        }
        currentCubes.Clear();
    }

    private void OnDestroy()
    {
        ClearCurrentBuilding();
    }
}