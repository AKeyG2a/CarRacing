using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Car_racing
{
    static class Pause
    {
        public static Texture2D Background { get; set; }
        public static SpriteFont Font { get; set; }
        public static Color _firstColor = Color.Gray;
        public static Color _secondColor = Color.White;
        private static readonly string _firstText = "Возобновить";
        private static readonly string _secondText = "Выйти";

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);

            spriteBatch.DrawString
            (
                Font,
                _firstText,
                new Vector2
                (
                    Background.Width / 2 - Font.MeasureString(_firstText).X / 2,
                    Background.Height / 2 - Font.MeasureString(_firstText).Y
                    ),
                _firstColor
                );

            spriteBatch.DrawString
            (
                Font,
                _secondText,
                new Vector2
                (
                    Background.Width / 2 - Font.MeasureString(_secondText).X / 2,
                    Background.Height / 2 + Font.MeasureString(_secondText).Y 
                    ),
                _secondColor
                );
        }

        public static void Up()
        {
            _firstColor = Color.Gray;
            _secondColor = Color.White;
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                Game1._stat = Stat.Game;
        }

        public static void Down()
        {
            _secondColor = Color.Gray;
            _firstColor = Color.White;
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Game1._stat = Stat.Game;
                Racing._isCrash = true;
            }
                
        }

    }
}
