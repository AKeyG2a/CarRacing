using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Car_racing
{
    class Score
    {
        public SpriteFont _Font { get; set; }

        public int _Score { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_Font, _Score.ToString(), new Vector2(5, 5), Color.White);
        }

        public void Update()
        {
            _Score++;
        }
    }
}
