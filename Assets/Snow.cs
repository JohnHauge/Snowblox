using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    [SerializeField] private int snowAmount;
    [SerializeField] private int minHorizontalSpawn;
    [SerializeField] private int maxHorizontalSpawn;
    [SerializeField] private int minVerticalSpawn;
    [SerializeField] private int maxVerticalSpawn;
    
    [SerializeField] private Mesh snowBlockMesh;
    [SerializeField] private Material snowBlockMaterial;
    
    private readonly List<SnowBlock> _snowBlock = new();

    private void Start()
    {
        for (var i = 0; i < snowAmount; i++)
        {
            var spawnPosition = new Vector3()
            {
                x = Mathf.Lerp(minHorizontalSpawn, maxHorizontalSpawn, Random.Range(0f, 1f)),
                z = Mathf.Lerp(minHorizontalSpawn, maxHorizontalSpawn, Random.Range(0f, 1f)),
                y = Mathf.Lerp(minVerticalSpawn, maxVerticalSpawn, Random.Range(0f, 1f))
            };
            _snowBlock.Add(new SnowBlock(spawnPosition,snowBlockMesh, snowBlockMaterial));
        }
    }

    private void Update()
    {
        for (var i = 0; i < snowAmount; i++)
        {
            _snowBlock[i].Update();
        }
    }
}

public class SnowBlock
{
    private Vector3 _position;
    private readonly Vector3 _spawnPosition;
    private readonly Mesh _mesh;
    private readonly Material _material;

    public SnowBlock(Vector3 position, Mesh mesh, Material material)
    {
        _spawnPosition = position;
        _position = _spawnPosition;
        _mesh = mesh;
        _material = material;
    }

    public void Update()
    {
        var noise = Mathf.PerlinNoise(_position.x, _position.y);
        if (_position.y >= 0.5f)
        {
            _position += Vector3.down * Time.deltaTime;
            _position += new Vector3(noise, noise, noise) * Time.deltaTime;
        }
        else _position = _spawnPosition;
        Graphics.DrawMesh(_mesh, _position,  Quaternion.identity, _material, 1);
    }
}
