using System.Collections.Generic;
using UnityEngine;

namespace SnowBlocks
{
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
                _snowBlock.Add(new SnowBlock(spawnPosition, snowBlockMesh, snowBlockMaterial));
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
}
