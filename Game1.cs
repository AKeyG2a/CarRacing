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
        private Racing _racing;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.IsBorderless = true;
            _splashScreen = new SplashScreen();
            _endGame = new EndGame();
            _pause = new Pause();
            //_racing = new Racing();
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
            _racing.Initialization(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight, _spriteBatch);
            _racing._tree1.Tree = Content.Load<Texture2D>("Tree_v2");
            _racing._tree2.Tree = Content.Load<Texture2D>("Tree_v2");
            _racing.Background = Content.Load<Texture2D>("BackgroundForGame");
            _racing.Player.PlayerCar = Content.Load<Texture2D>("PlayerCar");
            _racing._stone1.StoneTexture = Content.Load<Texture2D>("Stone");
            _racing._stone2.StoneTexture = Content.Load<Texture2D>("Stone");
            _racing._score._Font = Content.Load<SpriteFont>("FontForScore");
            _endGame.Background = Content.Load<Texture2D>("BackgroundForGame");
            _endGame.Font = Content.Load<SpriteFont>("SplashFont");
            _pause.Background = Content.Load<Texture2D>("BackgroundForGame");
            _pause.Font = Content.Load<SpriteFont>("SplashFont");
            _racing._shield.Texture = Content.Load<Texture2D>("shield");
            _racing._shield._font = Content.Load<SpriteFont>("FontForScore");
            _racing._scoreBuster.Texture = Content.Load<Texture2D>("ScoreBuster");
            _racing.Player.SetRect();
            _racing._stone1.SetRect();
            _racing._stone2.SetRect();
            _racing._shield.SetRect();
            _racing._scoreBuster.SetRect();


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
                    _racing.Update();
                    if (keyboardState.IsKeyDown(Keys.Escape))
                        _stat = Stat.Pause;
                    if (keyboardState.IsKeyDown(Keys.Up))
                        _racing.Player.Up();
                    if (keyboardState.IsKeyDown(Keys.Down))
                        _racing.Player.Down();
                    if (keyboardState.IsKeyDown(Keys.Left))
                        _racing.Player.Left();
                    if (keyboardState.IsKeyDown(Keys.Right))
                        _racing.Player.Right();
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
                    _racing.Draw(_spriteBatch);
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
