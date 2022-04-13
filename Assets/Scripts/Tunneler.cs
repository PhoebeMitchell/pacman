using RandomGeneration;
using UnityEngine;

public class Tunneler
{
    private readonly Map _map;
    private readonly IRandom _random;
    private (int, int) _position;
    
    public Tunneler(Map map, IRandom random, (int, int) startPosition)
    {
        _map = map;
        _random = random;
        _map.SetVisited(startPosition.Item1, startPosition.Item1);
        _position = startPosition;
    }

    public void Tunnel()
    {
        var (x, y) = GetDirection();
        _position.Item1 += x;
        _position.Item2 += y;

        Debug.Log(_position.Item1 + " " + _position.Item2);
        
        if (_map.IsValid(_position.Item1, _position.Item2))
        {
            _map.SetVisited(_position.Item1, _position.Item2);
        }
    }

    private (int, int) GetDirection() => _random.Next() < 0.5f ? (0, 1) : (1, 0);
}