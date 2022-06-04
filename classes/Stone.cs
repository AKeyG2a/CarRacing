using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Car_racing
{
    public class Stone
    {
        public Texture2D StoneTexture { get; set; }
        public Vector2 _position;
        public Vector2 _direction;
        public Rectangle _rect;
        public float _speed;

        public Stone()
        {
            _speed = 5;
            RandomSet();
        }

        public void SetRect()
        {
            _rect = new Rectangle((int)_position.X, (int)_position.Y, StoneTexture.Width, StoneTexture.Height);
        }

        public void Update()
        {
            _position += _direction;
            _rect.X = (int)_position.X;
            _rect.Y = (int)_position.Y;
            _speed = _speed < 7.5 ? _speed * 1.0002f : 7.5f;
            _direction.Y = _speed;
            if (_position.Y > Racing._height)
                RandomSet();
        }

        public void RandomSet()
        {
            _position = new Vector2(Racing.GetRandom(150, Racing.Background.Width - 270), Racing.GetRandom(-800, -240));
            _direction = new Vector2(0, _speed);
        }

        public void Draw()
        {
            Racing._spriteBatch.Draw(StoneTexture, _position, Color.White);
        }
    }
}
