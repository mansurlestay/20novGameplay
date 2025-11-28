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
    private int rangeThickness = 1;
    // private Rectangle strikeRectangle;
    private Rectangle[] pointRecArr = new Rectangle[360];
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
            // StrikeRangeRec();
            VisualStrikeRadius();
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

    public void VisualStrikeRadius()
    {
        int radius = strikeRange * _tileRec.Width;
        Vector2 circleCenter = new Vector2(_tileRec.X + (_tileRec.Width / 2), _tileRec.Y + (_tileRec.Height / 2));
        for(int i=0; i < pointRecArr.GetLength(0); i++)
        {
            double angle = ((2 * Math.PI) / pointRecArr.GetLength(0)) * i;
            Vector2 pointPos = new Vector2((int)(radius * Math.Sin(angle) + circleCenter.X), (int)(radius * Math.Cos(angle)) + circleCenter.Y);
            pointRecArr[i] = new Rectangle((int)pointPos.X, (int)pointPos.Y, rangeThickness, rangeThickness);
        }
    }

    // public void StrikeRangeRec()
    // {
    //     strikeRectangle = new Rectangle(_tileRec.X - (strikeRange * _tileRec.Width), _tileRec.Y - (strikeRange * _tileRec.Height), 
    //     _tileRec.Width + (2 * strikeRange * _tileRec.Width), _tileRec.Height + (2 * strikeRange * _tileRec.Height));
    // }

    // public void DrawRange(SpriteBatch sBatch)
    // {
    //     //top
    //     sBatch.Draw(_tileTex, new Rectangle(strikeRectangle.X, strikeRectangle.Y, strikeRectangle.Width, rangeThickness), Color.Red);
    //     //left
    //     sBatch.Draw(_tileTex, new Rectangle(strikeRectangle.X, strikeRectangle.Y, rangeThickness, strikeRectangle.Height), Color.Red);
    //     //right
    //     sBatch.Draw(_tileTex, new Rectangle(strikeRectangle.X + strikeRectangle.Width - rangeThickness, strikeRectangle.Y, rangeThickness, strikeRectangle.Height), Color.Red);
    //     //bottom
    //     sBatch.Draw(_tileTex, new Rectangle(strikeRectangle.X, strikeRectangle.Y + (strikeRectangle.Height - rangeThickness), strikeRectangle.Width, rangeThickness), Color.Red);
    // }

    public void DrawRadius(SpriteBatch sBatch)
    {
        foreach(Rectangle rec in pointRecArr)
        {
            sBatch.Draw(_tileTex, rec, Color.Crimson);
        }
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