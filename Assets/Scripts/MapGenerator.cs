using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    private Tilemap _tilemap;
    
    private void Awake()
    {
        _tilemap = GetComponent<Tilemap>();
    }
}
