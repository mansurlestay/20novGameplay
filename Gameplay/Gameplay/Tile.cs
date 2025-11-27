using System;
using System.Diagnostics;
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
    private int outline = 1;
    private int strikeRange = 1;
    private int rangeThickness = 10;
    private Rectangle strikeRectangle;
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
            StrikeRangeRec();
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

    public void StrikeRangeRec()
    {
        strikeRectangle = new Rectangle(_tileRec.X - (strikeRange * _tileRec.Width), _tileRec.Y - (strikeRange * _tileRec.Height), 
        _tileRec.Width + (2 * strikeRange * _tileRec.Width), _tileRec.Height + (2 * strikeRange * _tileRec.Height));
    }

    public void DrawTile(SpriteBatch sBatch)
    {

        sBatch.Draw(_tileTex, _tileRec, _tileColor);
        #region TileOutline
        sBatch.Draw(_tileTex, new Rectangle(_tileRec.X, _tileRec.Y, outline, _tileRec.Height), Color.Black);
        sBatch.Draw(_tileTex, new Rectangle(_tileRec.X, _tileRec.Y, _tileRec.Width, outline), Color.Black);
        sBatch.Draw(_tileTex, new Rectangle(_tileRec.X + _tileRec.Width - outline, _tileRec.Y, outline, _tileRec.Height), Color.Black);
        sBatch.Draw(_tileTex, new Rectangle(_tileRec.X, _tileRec.Y + _tileRec.Height - outline, _tileRec.Width, outline), Color.Black);
        #endregion

        #region TowerRange
        if(Type == TileType.Tower)
        {
            //top
            sBatch.Draw(_tileTex, new Rectangle(strikeRectangle.X, strikeRectangle.Y, strikeRectangle.Width, rangeThickness), Color.Red);
            //left
            sBatch.Draw(_tileTex, new Rectangle(strikeRectangle.X, strikeRectangle.Y, rangeThickness, strikeRectangle.Height), Color.Red);
            //right
            sBatch.Draw(_tileTex, new Rectangle(strikeRectangle.X + strikeRectangle.Width - rangeThickness, strikeRectangle.Y, rangeThickness, strikeRectangle.Height), Color.Red);
            //bottom
            sBatch.Draw(_tileTex, new Rectangle(strikeRectangle.X, strikeRectangle.Y + (strikeRectangle.Height - rangeThickness), strikeRectangle.Width, rangeThickness), Color.Red);
        }
        #endregion
    }


}