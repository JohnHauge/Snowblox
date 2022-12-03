using UnityEngine;

namespace SnowBlocks
{
    public class SnowBlock
    {
        private Vector3 _position;
        private readonly Vector3 _spawnPosition;
        private readonly Mesh _mesh;
        private readonly Material _material;
        private readonly Camera _camera;

        public SnowBlock(Vector3 position, Mesh mesh, Material material)
        {
            _spawnPosition = position;
            _position = _spawnPosition;
            _position.y = Random.Range(0f, _position.y);
            _mesh = mesh;
            _material = material;
            _camera = Camera.main;
        }

        public void Update()
        {
            var noise = Mathf.PerlinNoise(-1f, 1f);
            if (_position.y >= 0.5f)
            {
                _position += Vector3.down * Time.deltaTime;
                _position += new Vector3(noise, noise, noise) * Time.deltaTime;
            }
            else _position = _spawnPosition;

            Graphics.DrawMesh(_mesh, _position, Quaternion.LookRotation(_camera.transform.forward), _material, 1,
                null, 0, null, false, false, false);
        }
    }
}