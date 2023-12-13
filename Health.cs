using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended;

namespace premiertest
{
    public class HealthBar
    {

        public float X {  get; set; }

        public float Y { get; set; }

        public const float Size = 30f;

        public HealthBar(float x, float y)
        {
            X = x;
            Y = y;
        }




        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float x = X;
            float y = Y;
            for (int i = 0; i<4; i++)
            {
                spriteBatch.DrawRectangle(new RectangleF(x, y, Size, Size), Color.Red, thickness: 3); //google enums
                x += 30;
            }

        }


    }
}
