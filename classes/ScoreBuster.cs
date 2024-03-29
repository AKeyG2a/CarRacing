﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Car_racing
{
    public class ScoreBuster
    {
        public static Texture2D Texture { get; set; }
        public Rectangle _rect;
        public Vector2 _position;
        public Vector2 _direction;
        public float _speed;

        public ScoreBuster()
        {
            _speed = 5;
            SetBuster();
        }

        public void Update()
        {
            _position += _direction;
            _rect.X = (int)_position.X;
            _rect.Y = (int)_position.Y;
            _speed = _speed < 7.5 ? _speed * 1.0002f : 7.5f;
            _direction.Y = _speed;
            if (_position.Y > Racing.Background.Height)
                SetBuster();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _position, Color.White);
        }

        public void SetRect()
        {
            _rect = new Rectangle((int)_position.X, (int)_position.Y, Texture.Width, Texture.Height);
        }

        public void SetBuster()
        {
            _position = new Vector2(Racing.GetRandom(150, 600), Racing.GetRandom(-1500, -1000));
            _direction = new Vector2(0, _speed);
        }
    }
}
