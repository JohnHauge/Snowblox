using UnityEngine;

namespace SnowBlocks
{
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

            Graphics.DrawMesh(_mesh, _position, Quaternion.identity, _material, 1);
        }
    }
}