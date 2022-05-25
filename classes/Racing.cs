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
        public  static Score _score;
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
        }

        public static void Update()
        {
            _tree1.Update();
            _tree2.Update();
            _stone1.Update();
            _stone2.Update();
            _score.Update();
            if (IsCrash())
            {
                EndGame._totalScore = _score;
                Game1._stat = Stat.Final;
            }
        }

        public static bool IsCrash()
        {
            if (Player._rect.Intersects(_stone1._rect) || Player._rect.Intersects(_stone2._rect))
                return true;
            return false;
        }

        public static void RestartGame()
        {
            //_tree1
            _tree1._position = new Vector2(0, -240);
            _tree1._direction = new Vector2(0, 5);

            //_tree2
            _tree2._position = new Vector2(655, 60);
            _tree2._direction = new Vector2(0, 5);

            //Player
            Player._position = new Vector2(_width / 2 - Player.PlayerCar.Width / 2,
                _height / 2 - Player.PlayerCar.Height / 2);
            Player._rect.X = _width / 2 - Player.PlayerCar.Width / 2;
            Player._rect.Y = _height / 2 - Player.PlayerCar.Height / 2;

            //_stone1
            _stone1._position = new Vector2(155, -200);
            _stone1._direction = new Vector2(0, 5);
            _stone1._rect.X = 155;
            _stone1._rect.Y = -200;

            //_stone2
            _stone2._position = new Vector2(455, -500);
            _stone2._direction = new Vector2(0, 5);
            _stone2._rect.X = 455;
            _stone2._rect.Y = -500;

            //_score;
            _score._Score = 0;
        }
    }
}
