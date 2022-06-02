using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Car_racing
{
    class EndGame
    {
        public static Texture2D Background { get; set; }
        public static SpriteFont Font { get; set; }
        public static string _text = "Вы проиграли";
        public static Score _totalScore;


        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);

            spriteBatch.DrawString
            (
                Font,
                _text,
                new Vector2
                (
                    Background.Width / 2 - Font.MeasureString(_text).X / 2,
                    Background.Height / 2 - Font.MeasureString(_text).Y
                ),
                Color.White
            );
            spriteBatch.DrawString
            (
                Font,
                _totalScore._Score.ToString(),
                new Vector2
                (
                    Background.Width / 2 - Font.MeasureString(_totalScore._Score.ToString()).X / 2,
                    Background.Height / 2 - Font.MeasureString(_totalScore._Score.ToString()).Y / 2 + 20
                ),
                Color.White
            );
        }

    }
}
