using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended;

namespace premiertest
{
    public class Projectiles
    {
        public float X {  get; set; }
        public float Y { get; set; }

        public const float Speed = 150f;
        public const float Size = 20f;

        Vector2 inputVector;
        int state = 0;


        Character character;

        public Projectiles(Character player)
        {
            X = player.X;
            Y = player.Y;
            character = player;
            inputVector = new Vector2(); //creating new vector puts coords to 0,0
        }



        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();


            if (keyState.IsKeyDown(Keys.Right) && state ==0)
            {
                inputVector.X = 1;
                state = 1;
            }
            else if (keyState.IsKeyDown(Keys.Left) && state == 0)
            {
                inputVector.X = -1;
                state = 1;
            }

            else if (keyState.IsKeyDown(Keys.Up) && state == 0)
            {
                inputVector.Y = -1;
                state = 1;
            }

            else if (keyState.IsKeyDown(Keys.Down) && state == 0)
            {
                inputVector.Y = 1;
                state = 1;
            }

            if (inputVector.Length() != 0)
            {
                inputVector = Vector2.Normalize(inputVector);
            }

            Vector2 moveVector = inputVector * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            X += moveVector.X;
            Y += moveVector.Y;

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawRectangle(new RectangleF(X - Size / 2, Y - Size / 2, Size, Size), Color.Black, thickness: 5); //google enums

        }






    }
}
