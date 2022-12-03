using System.Collections.Generic;
using UnityEngine;

namespace SnowBlocks
{
    public class Snow : MonoBehaviour
    {
        [SerializeField] private SnowSettings snowSettings;
        [SerializeField] private Mesh snowBlockMesh;
        [SerializeField] private Material snowBlockMaterial;

        private readonly List<SnowBlock> _snowBlocks = new();

        private void Start()
        {
            for (var i = 0; i < snowSettings.snowAmount; i++)
            {
                var spawnPosition = new Vector3()
                {
                    x = Mathf.Lerp(snowSettings.minHorizontalSpawn, snowSettings.maxHorizontalSpawn, Random.Range(0f, 1f)),
                    z = Mathf.Lerp(snowSettings.minHorizontalSpawn, snowSettings.maxHorizontalSpawn, Random.Range(0f, 1f)),
                    y = Mathf.Lerp(snowSettings.minVerticalSpawn, snowSettings.maxVerticalSpawn, Random.Range(0f, 1f))
                };
                _snowBlocks.Add(new SnowBlock(spawnPosition, snowBlockMesh, snowBlockMaterial));
            }
        }

        private void Update()
        {
            foreach (var snowBlock in _snowBlocks) snowBlock.Update();
        }
    }
}
