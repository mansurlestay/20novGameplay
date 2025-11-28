using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gameplay;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public Texture2D texture;
    public Texture2D circle;
    private Vector2[] arrPoints = new Vector2[360];
    private int xTiles = 11;
    private int yTiles = 11;
    private int screenWidth = 880;
    private int screenHeight = 880;
    private ArrayManager arrM;
    private MouseState mouseState;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferHeight = screenHeight;
        _graphics.PreferredBackBufferWidth = screenWidth;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Vector2 circleCentre = new Vector2(2,4);
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here


        texture = new Texture2D(GraphicsDevice,1,1);
        texture.SetData(new[] {Color.White});

        arrM = new ArrayManager(texture, xTiles, yTiles, screenWidth, screenHeight);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        mouseState = Mouse.GetState();
        if(mouseState.LeftButton == ButtonState.Pressed)
        {
            arrM.TileClicked(mouseState);
        }
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        arrM.DrawArray(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
