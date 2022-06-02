using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Car_racing
{
    static class SplashScreen
    {
        public static Texture2D Background { get; set; }
        private static int _timeCounter = 0;
        private static Color _color = Color.White;
        public static SpriteFont Font { get; set; }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Font,"Старт", new Vector2(20, 20), _color);
        }

        public static void Update()
        { 
            _timeCounter++;
            _color = Color.FromNonPremultiplied(255, 255, 255, _timeCounter % 256);
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                Game1._stat = Stat.Game;
        }
    }
}
