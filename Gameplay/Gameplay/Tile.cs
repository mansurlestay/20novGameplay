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
    }

    

    public void DrawTile(SpriteBatch sBatch)
    {
        sBatch.Draw(_tileTex, _tileRec, _tileColor);
    }


}