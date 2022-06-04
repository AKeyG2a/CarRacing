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
        public PauseState pauseState = PauseState.Resume;
        private SplashScreen _splashScreen;
        private EndGame _endGame;
        private Pause _pause;
        public Game1()
        {
            _splashScreen = new SplashScreen();
            _endGame = new EndGame();
            _pause = new Pause();
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
            _splashScreen.Background = Content.Load<Texture2D>("BFSS");
            _splashScreen.Font = Content.Load<SpriteFont>("SplashFont");
            Racing.Background = Content.Load<Texture2D>("BackgroundForGame");
            Racing.Initialization(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, _spriteBatch);
            Racing._tree1.Tree = Content.Load<Texture2D>("Tree_v2");
            Racing._tree2.Tree = Content.Load<Texture2D>("Tree_v2");
            Racing.Player.PlayerCar = Content.Load<Texture2D>("PlayerCar");
            Racing.Player.SetRect();
            Racing._stone1.StoneTexture = Content.Load<Texture2D>("Stone");
            Racing._stone1.SetRect();
            Racing._stone2.StoneTexture = Content.Load<Texture2D>("Stone");
            Racing._stone2.SetRect();
            Racing._stone3.StoneTexture = Content.Load<Texture2D>("Stone");
            Racing._stone3.SetRect();
            Racing._superStone.Texture = Content.Load<Texture2D>("SuperStone");
            Racing._superStone.Font = Content.Load<SpriteFont>("SplashFont");
            Racing._superStone.SetRect();
            _endGame.Background = Content.Load<Texture2D>("BackgroundForGame");
            _endGame.Font = Content.Load<SpriteFont>("SplashFont");
            _pause.Background = Content.Load<Texture2D>("BackgroundForGame");
            _pause.Font = Content.Load<SpriteFont>("SplashFont");
            Racing._shield.Texture = Content.Load<Texture2D>("shield");
            Racing._shield._font = Content.Load<SpriteFont>("FontForScore");
            Racing._shield.SetRect();
            Score._Font = Content.Load<SpriteFont>("FontForScore");
            ScoreBuster.Texture = Content.Load<Texture2D>("ScoreBuster");
            Racing._scoreBuster.SetRect();
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            

            switch (_stat)
            {
                case Stat.SplashScreen:
                    _splashScreen.Update();
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
                        _pause.Down();

                    if (pauseState == PauseState.Resume)
                        _pause.Up();
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
                    _splashScreen.Draw(_spriteBatch);
                    break;
                case Stat.Game:
                    Racing.Draw(_spriteBatch);
                    break;
                case Stat.Final:
                    _endGame.Draw(_spriteBatch);
                    break;
                case Stat.Pause:
                    _pause.Draw(_spriteBatch);
                    break;
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
