using System;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gameplay;

public class Tile
{
    private Texture2D _tileTex;
    private Rectangle _tileRec;
    private Color _tileColor;
    private int outline = 1;
    public Tower _tower;
    public bool isTraversable = false;
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
            isTraversable = true;
        }
        else if(Type == TileType.Tower)
        {
            _tileColor = Color.White;
            _tower = new Tower(_tileTex, _tileRec);
        }
        else if(Type == TileType.PreTower)
        {
            _tileColor = Color.LightGray;
        }
        else
        {
            _tileColor = Color.White;
            isTraversable = true;
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
    public void DrawTileOutline(SpriteBatch sBatch)
    {
        sBatch.Draw(_tileTex, new Rectangle(_tileRec.X, _tileRec.Y, outline, _tileRec.Height), Color.Black);
        sBatch.Draw(_tileTex, new Rectangle(_tileRec.X, _tileRec.Y, _tileRec.Width, outline), Color.Black);
        sBatch.Draw(_tileTex, new Rectangle(_tileRec.X + _tileRec.Width - outline, _tileRec.Y, outline, _tileRec.Height), Color.Black);
        sBatch.Draw(_tileTex, new Rectangle(_tileRec.X, _tileRec.Y + _tileRec.Height - outline, _tileRec.Width, outline), Color.Black);
    }
    public void DrawTile(SpriteBatch sBatch)
    {
        sBatch.Draw(_tileTex, _tileRec, _tileColor);
    }
}