﻿using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Car_racing
{

    public class Game1 : Game
    {
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static Stat _stat = Stat.SplashScreen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.ToggleFullScreen();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SplashScreen.Background = Content.Load<Texture2D>("BFSS");
            SplashScreen.Font = Content.Load<SpriteFont>("SplashFont");
            Racing.Initialization(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, _spriteBatch);
            Trees.Tree = Content.Load<Texture2D>("Tree_v2");
            Racing.Background = Content.Load<Texture2D>("BackgroundForGame");
            Racing.Player.PlayerCar = Content.Load<Texture2D>("PlayerCar");
            Stone.StoneTexture = Content.Load<Texture2D>("Stone");
            Score._Font = Content.Load<SpriteFont>("FontForScore");
            EndGame.Background = Content.Load<Texture2D>("BackgroundForGame");
            EndGame.Font = Content.Load<SpriteFont>("SplashFont");
            Pause.Background = Content.Load<Texture2D>("BackForGame");
            Pause.Font = Content.Load<SpriteFont>("FontToEndGame");
            Racing.Player.SetRect();
            Racing._stone1.SetRect();
            Racing._stone2.SetRect();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            switch (_stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Update();
                    if (keyboardState.IsKeyDown(Keys.Enter))
                        _stat = Stat.Game;
                    break;
                case Stat.Game:
                    Racing.Update();
                    if (keyboardState.IsKeyDown(Keys.Escape))
                        _stat = Stat.Pause;
                    if (keyboardState.IsKeyDown(Keys.Up))
                        Racing.Player.Up();
                    if (keyboardState.IsKeyDown(Keys.Down))
                        Racing.Player.Down();
                    if (keyboardState.IsKeyDown(Keys.Left))
                        Racing.Player.Left();
                    if (keyboardState.IsKeyDown(Keys.Right))
                        Racing.Player.Right();
                    break;
                case Stat.Final:
                    if (keyboardState.IsKeyDown(Keys.Escape))
                        _stat = Stat.SplashScreen;
                    Racing.RestartGame();
                    break;
                case Stat.Pause:
                    Pause.Up();
                    if (keyboardState.IsKeyDown(Keys.Down))
                    {
                        Pause.Down();
                        if (keyboardState.IsKeyDown(Keys.Enter))
                            _stat = Stat.SplashScreen;
                    }

                    if (keyboardState.IsKeyDown(Keys.Up))
                    {
                        Pause.Up();
                        if (keyboardState.IsKeyDown(Keys.Enter))
                            _stat = Stat.Game;
                    }
                        
                    break;
            }

            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();*/

            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            switch (_stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Draw(_spriteBatch);
                    break;
                case Stat.Game:
                    Racing.Draw(_spriteBatch);
                    break;
                case Stat.Final:
                    EndGame.Draw(_spriteBatch);
                    break;
                case Stat.Pause:
                    Pause.Draw(_spriteBatch);
                    break;
            }
            
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        protected override 
    }
}