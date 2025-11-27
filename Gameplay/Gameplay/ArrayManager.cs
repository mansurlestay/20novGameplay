using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gameplay;

public class ArrayManager
{
    public Tile[,] TileArray;
    private int _tileWidth, _tileHeight;
    private int enemyRow;
    public ArrayManager(Texture2D tileTex, int arrX, int arrY, int screenWidth, int screenHeight)
    {
        TileArray = new Tile[arrX,arrY];
        _tileWidth = screenWidth / arrX; // I didn't mention this in the commits. This and the next line use the screen width and the screen height to calculate how long and tall should the tiles be to cover the whole screen.
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
        MapMiddlePath();
        TowerPlacements();
    }

#region middleEnemyPath
    public void MapMiddlePath()
    {        
        int remainderY = TileArray.GetLength(0) % 2;

        for(int j = 0; j < TileArray.GetLength(1); j++)
        {
            TileArray[(TileArray.GetLength(0) - remainderY) / 2,j].SetType(Tile.TileType.Path);
        }
        
        enemyRow = (TileArray.GetLength(0) - remainderY) / 2;
    }
    #endregion

    public void TowerPlacements()
    {
        for(int i = 0; i < TileArray.GetLength(1); i += 2)
        {
            TileArray[enemyRow - 2, i].SetType(Tile.TileType.PreTower);   
        }
        for(int i = 0; i < TileArray.GetLength(1); i += 2)
        {
            TileArray[enemyRow + 2, i].SetType(Tile.TileType.PreTower);   
        }
    }
    public void TileClicked(MouseState mouseState)
    {
        foreach(Tile tile in TileArray)
        {
            if(tile.ClickedOn(mouseState) == true)
            {
                if(tile.Type == Tile.TileType.PreTower)
                {
                    tile.SetType(Tile.TileType.Tower);
                }
            }
        }
    }

    public void DrawArray(SpriteBatch sBatch)
    {
        foreach(Tile tile in TileArray)
        {
            tile.DrawTile(sBatch);
        }
        foreach(Tile tile in TileArray)
        {
            tile.DrawTileOutline(sBatch);
        }
        foreach(Tile tile in TileArray)
        {
            if(tile.Type == Tile.TileType.Tower)
            {
                tile.DrawRange(sBatch);
            }
        }
    }
}