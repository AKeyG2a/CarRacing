using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Car_racing
{
    class Pause
    {
        public static Texture2D Background { get; set; }
        public static SpriteFont Font { get; set; }
        public static Color _firstColor;
        public static Color _secondColor;
        public static int _firstTimer = 0;
        public static int _secondTimer = 0;
        private static string _firstText = "Возобновить";
        private static string _secondText = "Выйти";

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Font, _firstText, new Vector2
            (
                Background.Width / 2 - Font.MeasureString(_firstText).X / 2,
                Background.Height / 2 - Font.MeasureString(_firstText).Y
            ),
                _firstColor);
            spriteBatch.DrawString(Font, _secondText, new Vector2
            (
                Background.Width / 2 - Font.MeasureString(_secondText).X / 2,
                Background.Height / 2 + Font.MeasureString(_secondText).Y 
            ),
                _secondColor);
        }

        public static void Up()
        {
            _firstTimer++;
            _firstColor = Color.FromNonPremultiplied(255, 255, 255, _firstTimer % 256);
        }

        public static void Down()
        {
            _secondTimer++;
            _secondColor = Color.FromNonPremultiplied(255, 255, 255, _secondTimer % 256);
        }

    }
}
