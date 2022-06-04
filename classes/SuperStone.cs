using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Car_racing
{
    public class SuperStone
    {
        public Texture2D Texture { get; set; }
        public SpriteFont Font { get; set; }
        public Vector2 _position;
        public Vector2 _direction;
        public Rectangle _rect;
        public float _speed = 8;

        public SuperStone()
        {
            SetSuperStone();
        }

        public void Update()
        {
            _position += _direction;
            _rect.X = (int)_position.X;
            _rect.Y = (int)_position.Y;
            if (_position.Y > Racing.Background.Height)
                SetSuperStone();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _position, Color.White);
            if (_position.Y > -1000 && _position.Y < -200)
                spriteBatch.DrawString(Font, "Внимание, впереди опасность!", new Vector2(
                    Racing._width / 2 - Font.MeasureString("Внимание, впереди опасность!").X / 2, 5), Color.White);
        }

        public void SetRect()
        {
            _rect = new Rectangle((int)_position.X, (int)_position.Y, Texture.Width, Texture.Height);
        }

        public void SetSuperStone()
        {
            _position = new Vector2(Racing.GetRandom(150, 550), Racing.GetRandom(-10000, -6000));
            _direction = new Vector2(0, _speed);
        }
    }
}
