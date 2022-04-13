using UnityEngine;
using UnityEngine.Tilemaps;
using RandomGeneration;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Tile _tile;
    
    private Tilemap _tilemap;

    private void Awake()
    {
        _tilemap = GetComponent<Tilemap>();

        var mainCamera = Camera.main;
        var dimensions = Vector2Int.FloorToInt(mainCamera.ViewportToWorldPoint(mainCamera.rect.max) - mainCamera.ViewportToWorldPoint(mainCamera.rect.min));
        var map = new Map(dimensions.x, dimensions.y);
        var tunneler = new Tunneler(map, new RandomGenerator(), (0, 0));

        for (var i = 0; i < 1000; i++)
        {
            tunneler.Tunnel();
        }
        DrawMap(map);
    }

    private void DrawMap(Map map)
    {
        foreach (var position in map)
        {
            _tilemap.SetTile(new Vector3Int(position.X, position.Y, 0), _tile);
        }
    }
}
