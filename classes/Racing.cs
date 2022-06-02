using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Car_racing
{
    class Racing
    {
        public static Texture2D Background { get; set; }
        public static int _width, _height;
        public static Random _random = new Random();
        public static SpriteBatch _spriteBatch;
        private static Trees _tree1;
        private static Trees _tree2;
        public static Stone _stone1;
        public static Stone _stone2;
        public static Score _score;
        public static Shield _shield;
        public static bool _isShieldActive;
        public static bool _isCrash;
        public static Player Player { get; set; }
        

        public static int GetRandom(int min, int max) => _random.Next(min, max);
        
        public static void Initialization(int width, int height, SpriteBatch spriteBatch)
        {
            _width = width;
            _height = height;
            _spriteBatch = spriteBatch;
            _tree1 = new Trees(new Vector2(0, -240), new Vector2(0, 5));
            _tree2 = new Trees(new Vector2(655, 60), new Vector2(0, 5));
            Player = new Player(new Vector2(width/2 - 23,height - 180));
            _stone1 = new Stone(new Vector2(155, -200), new Vector2(0, 5));
            _stone2 = new Stone(new Vector2(455, -500), new Vector2(0, 5));
            _shield = new Shield();
            _score = new Score();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            _spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            _tree1.Draw();
            _tree2.Draw();
            _stone1.Draw();
            _stone2.Draw();
            Player.Draw();
            _score.Draw(spriteBatch);
            _shield.Draw();
        }

        public static void Update()
        {
            _tree1.Update();
            _tree2.Update();
            _stone1.Update();
            _stone2.Update();
            _score.Update();
            _shield.Update();
            GetIsCrash();
            if (_isCrash)
            {
                EndGame._totalScore = _score;
                RestartGame();
                Game1._stat = Stat.Final;
            }
            GetIsShieldActive();
        }

        public static void GetIsCrash()
        {
            if ((Player._rect.Intersects(_stone1._rect) || Player._rect.Intersects(_stone2._rect)) && !_isShieldActive)
                _isCrash = true;
        }



        public static void GetIsShieldActive()
        {
            if (Player._rect.Intersects(_shield._rect))
                _isShieldActive = true;

            if (_shield._helth == 0)
            {
                _isShieldActive = false;
                _shield._helth = 600;
            }

            if (_isShieldActive && Player._rect.Intersects(_stone1._rect))
            {
                _stone1.RandomSet();
                _isShieldActive = false;
            }

            if (_isShieldActive && Player._rect.Intersects(_stone2._rect))
            {
                _stone2.RandomSet();
                _isShieldActive = false;
            }
        }
                

        public static void RestartGame()
        {
            //_tree1
            _tree1._position = new Vector2(0, -240);
            _tree1._direction = new Vector2(0, 5);
            _tree1._speed = 5;

            //_tree2
            _tree2._position = new Vector2(655, 60);
            _tree2._direction = new Vector2(0, 5);
            _tree2._speed = 5;

            //Player
            Player._position = new Vector2(_width / 2 - Player.PlayerCar.Width / 2,
                _height / 2 - Player.PlayerCar.Height / 2);
            Player._rect.X = (int)Player._position.X;
            Player._rect.Y = (int)Player._position.Y;

            //_stone1
            _stone1._position = new Vector2(155, -200);
            _stone1._direction = new Vector2(0, 5);
            _stone1._rect.X = (int)_stone1._position.X;
            _stone1._rect.Y = (int)_stone1._position.Y;
            _stone1._speed = 5;

            //_stone2
            _stone2._position = new Vector2(455, -500);
            _stone2._direction = new Vector2(0, 5);
            _stone2._rect.X = (int)_stone2._position.X;
            _stone2._rect.Y = (int)_stone2._position.Y;
            _stone2._speed = 5;

            //_shield
            _shield = new Shield();
            _shield._rect.Y = (int)_shield._position.Y;
            _shield._rect.X = (int)_shield._position.X;
            _shield._speed = 5;

            //_score;
            _score = new Score();

            //_isCrash
            _isCrash = false;

            //_isShieldActive
            _isShieldActive = false;
        }
    }
}
