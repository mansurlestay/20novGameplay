using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gameplay;

public class Tower
{
    private Rectangle _rectangle;
    private Color _color = Color.Yellow;
    private Texture2D _tex;
    private double strikeRange = 2.75;
    private int rangeThickness = 4;
    private Rectangle[] pointRecArr = new Rectangle[360];

    public Tower(Texture2D tex, Rectangle rectangle)
    {
        _tex = tex;
        _rectangle = rectangle;
        VisualStrikeRadius();
    }

    public void VisualStrikeRadius()
    {
        double radius = strikeRange * _rectangle.Width;
        Vector2 circleCenter = new Vector2(_rectangle.X + (_rectangle.Width / 2), _rectangle.Y + (_rectangle.Height / 2));
        for(int i=0; i < pointRecArr.GetLength(0); i++)
        {
            double angle = ((2 * Math.PI) / pointRecArr.GetLength(0)) * i;
            Vector2 pointPos = new Vector2((int)(radius * Math.Sin(angle) + circleCenter.X), (int)(radius * Math.Cos(angle)) + circleCenter.Y);
            pointRecArr[i] = new Rectangle((int)pointPos.X, (int)pointPos.Y, rangeThickness, rangeThickness);
        }
    }

    public void DrawRadius(SpriteBatch sBatch)
    {
        foreach(Rectangle rec in pointRecArr)
        {
            sBatch.Draw(_tex, rec, Color.Crimson);
        }
    }

    public void Draw(SpriteBatch sBatch)
    {
        sBatch.Draw(_tex, _rectangle, _color);
    }
}