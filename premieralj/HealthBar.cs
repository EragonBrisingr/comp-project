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

        public float x = 20;

        public float y = 20;

        public float initialHealh = 4;

        public const float Size = 30f;

        Character character;

        public HealthBar(Character character)
        {
            this.character = character;
        }


        public void Update(GameTime gameTime)
        {


        }


        public void Draw(SpriteBatch spriteBatch)
        {
            Debug.WriteLine(character.Health);
            for (int i = 0; i < character.Health; i++)
            {
                spriteBatch.DrawRectangle(new RectangleF(x + i * (Size + 10), y, Size, Size), Color.Red, thickness: 3); //google enums

            }


        }


    }
}
