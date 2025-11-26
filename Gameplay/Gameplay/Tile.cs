using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gameplay;

public class Tile
{
    private Texture2D _tileTex;
    private Rectangle _tileRec;
    private Color _tileColor;
    public enum TileType
    {
        Path,
        Tower,
        PreTower,
        MapTile
    }
    public TileType Type;

    public Tile(Texture2D tileTex, int x, int y, int width, int height, TileType tileType)
    {
        _tileTex = tileTex;
        _tileRec = new Rectangle(x,y, width, height);
        Type = tileType;
        TileConfiguration();
    }
    public void TileConfiguration()
    {
        if(Type == TileType.Path)
        {
            _tileColor = Color.PaleGreen;
        }
        else if(Type == TileType.Tower)
        {
            _tileColor = Color.Yellow;
        }
        else if(Type == TileType.PreTower)
        {
            _tileColor = Color.LightGray;
        }
        else
        {
            _tileColor = Color.White;
        }
    }
    public bool ClickedOn(MouseState mouseState)
    {
        if(_tileRec.Contains(mouseState.Position))
        {
           return true; 
        }
        else
        {
            return false;
        }
    }

    public void SetType(TileType newType)
    {
        Type = newType;
        TileConfiguration();
    }

    public void DrawTile(SpriteBatch sBatch)
    {
        sBatch.Draw(_tileTex, _tileRec, _tileColor);
    }


}