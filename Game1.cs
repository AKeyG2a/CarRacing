using System.Diagnostics;
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
        public static PauseState pauseState = PauseState.Resume;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.IsBorderless = true;

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
            Pause.Background = Content.Load<Texture2D>("BackgroundForGame");
            Pause.Font = Content.Load<SpriteFont>("SplashFont");
            Shield.Texture = Content.Load<Texture2D>("shield");
            Racing.Player.SetRect();
            Racing._stone1.SetRect();
            Racing._stone2.SetRect();
            Racing._shield.SetRect();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            

            switch (_stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Update();
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
                    if (keyboardState.IsKeyDown(Keys.Escape) 
                        || keyboardState.IsKeyDown(Keys.Space))
                        _stat = Stat.SplashScreen;
                    break;
                case Stat.Pause:
                    if (keyboardState.IsKeyDown(Keys.Down))
                        pauseState = PauseState.Exit;

                    if (keyboardState.IsKeyDown(Keys.Up))
                        pauseState = PauseState.Resume;

                    if (pauseState == PauseState.Exit)
                        Pause.Down();

                    if (pauseState == PauseState.Resume)
                        Pause.Up();
                    break;
            }

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
    }
}
