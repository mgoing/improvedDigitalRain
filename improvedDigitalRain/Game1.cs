using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace improvedDigitalRain
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private Random _random;

        private const int CharSize = 16; // Size of characters
        private char[] _characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()".ToCharArray();
        private MatrixColumn[] _columns; // Array to store column data

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

            // Set window size
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            _random = new Random();

            // Initialize columns
            int numColumns = _graphics.PreferredBackBufferWidth / CharSize;
            _columns = new MatrixColumn[numColumns];
            for (int i = 0; i < numColumns; i++)
            {
                _columns[i] = new MatrixColumn(_random, _graphics.PreferredBackBufferHeight / CharSize);
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load a font
            _font = Content.Load<SpriteFont>("MatrixFont.spritefont"); // Ensure "MatrixFont" is added in Content.mgcb
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update each column
            foreach (var column in _columns)
            {
                column.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // Draw each column
            for (int i = 0; i < _columns.Length; i++)
            {
                _columns[i].Draw(_spriteBatch, _font, i * CharSize, CharSize);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
