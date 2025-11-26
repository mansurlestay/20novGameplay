using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gameplay;

public class ArrayManager
{
    public Tile[,] TileArray;
    private int _tileWidth, _tileHeight;
    public ArrayManager(Texture2D tileTex, int arrX, int arrY, int screenWidth, int screenHeight)
    {
        TileArray = new Tile[arrX,arrY];
        _tileWidth = screenWidth / arrX;
        _tileHeight = screenHeight / arrY;
        InitializeArray(tileTex);
    }

    public void InitializeArray(Texture2D tileTex)
    {
        for(int i=0;i<TileArray.GetLength(0);i++)
        {
            for(int j = 0; j < TileArray.GetLength(1); j++)
            {
                TileArray[i,j] = new Tile(tileTex, j*_tileWidth, i*_tileHeight, _tileWidth, _tileHeight, Tile.TileType.MapTile);
            }
        }
    }

    public void DrawArray(SpriteBatch sBatch)
    {
        foreach(Tile tile in TileArray)
        {
            tile.DrawTile(sBatch);
        }
    }
}