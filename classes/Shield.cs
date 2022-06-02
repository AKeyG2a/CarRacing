using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Car_racing
{
    class Shield
    {
        public Texture2D Texture { get; set; }
        public Rectangle _rect;
        public Vector2 _position;
        public Vector2 _direction;
        public SpriteFont _font;
        public int _helth;
        public float _speed;
        public Racing _racing;

        public Shield()
        {
            _helth = 600;
            _speed = 5;
            SetShield();
        }

        public void SetRect()
        {
            _rect = new Rectangle((int)_position.X, (int)_position.Y, Texture.Width, Texture.Height);
        }

        public void Update()
        {
            _position += _direction;
            _rect.X = (int)_position.X;
            _rect.Y = (int)_position.Y;
            _speed = _speed < 7.5 ? _speed * 1.0002f : 7.5f;
            _direction.Y = _speed;
            if (Racing._isShieldActive)
            {
                _helth--;
                SetShield();
            }
            
            if (_position.Y > Racing.Background.Height)
                SetShield();
        }

        public void Draw()
        {
            Racing._spriteBatch.Draw(Texture, _position, Color.White);
            if (Racing._isShieldActive)
                Racing._spriteBatch.DrawString(_font, (_helth / 60 + 1).ToString(), new Vector2(750, 5), Color.White);
        }

        private void SetShield()
        {
            _position = new Vector2(Racing.GetRandom(150, 600), Racing.GetRandom(-2500, -1500));
            _direction = new Vector2(0, _speed);
        }
    }
}
