using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Map : IEnumerable<Position>
{
    private readonly Position[,] _map;
    private readonly int _width;
    private readonly int _height;

    public Map(int width, int height)
    {
        _width = width;
        _height = height;
        _map = new Position[width, height];
    }

    public bool IsValid(int width, int height)
    {
        if (width >= _width || width < 0 || height >= _height || height < 0)
        {
            return false;
        }
        
        return !_map[width, height].Value;
    }

    public void SetVisited(int width, int height)
    {
        _map[width, height].Value = true;
    }

    IEnumerator<Position> IEnumerable<Position>.GetEnumerator()
    {
        return _map.Cast<Position>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _map.GetEnumerator();
    }
}