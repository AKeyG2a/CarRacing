using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Car_racing
{
    class Trees
    {
        public static Texture2D Tree { get; set; }
        public Vector2 _position;
        public Vector2 _direction;
        public float _speed = 5;

        public Trees(Vector2 position, Vector2 direction)
        {
            _position = position;
            _direction = direction;
        }

        public Trees(Vector2 direction)
        {
            _direction = direction;
        }

        public Trees()
        {
            RandomSet();
        }

        public void Update()
        {
            _position += _direction;
            _speed *= 1.00002f;
            _direction.Y = _speed;
            if (_position.Y > Racing._height)
                RandomSet();
        }

        private void RandomSet()
        {
            var rnd = new Random().Next(0, 2);
            if (rnd % 2 == 1)
                _position = new Vector2(Racing.GetRandom(650, 670), -240);
            if (rnd % 2 == 0)
                _position = new Vector2(Racing.GetRandom(0, 20), -240);
        }

        public void Draw()
        {
            Racing._spriteBatch.Draw(Tree, _position, Color.White);
        }
    }
}
