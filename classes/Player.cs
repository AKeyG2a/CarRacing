using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Car_racing
{
    public class Player
    {
        public Texture2D PlayerCar { get; set; }
        public Vector2 _position;
        public Rectangle _rect;
        public int _speed = 5;

        public Player(Vector2 position)
        {
            _position = position;
        }

        public void SetRect()
        {
            _rect = new Rectangle((int)_position.X, (int)_position.Y, PlayerCar.Width, PlayerCar.Height);
        }

        public void Draw()
        {
            Racing._spriteBatch.Draw(PlayerCar, _position, Color.White);
        }

        public void Up()
        {
            if (_position.Y > 0)
            {
                _position.Y -= _speed;
                _rect.Y -= _speed;
            }
                

        }

        public void Down()
        {
            if (_position.Y < Racing._height - 105) 
                
            {
                _position.Y += _speed;
                _rect.Y += _speed;
            }
        }

        public void Left()
        {
            if (_position.X > 152)
            {
                _position.X -= _speed;
                _rect.X -= _speed;
            }
                
                
        }

        public void Right()
        {
            if (_position.X < 598)
            {
                _position.X += _speed;
                _rect.X += _speed;
            }
                
        }
    }
}
