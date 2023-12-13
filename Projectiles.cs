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
    public class Projectiles
    {
        public float X {  get; set; }
        public float Y { get; set; }

        public const float Speed = 150f;
        public const float Size = 20f;

        Vector2 inputVector;




        Character character;

        public Projectiles(Character player, Vector2 shootDir)
        {
            X = player.X;
            Y = player.Y;
            character = player;
            inputVector = new Vector2(shootDir.X, shootDir.Y); //creating new vector puts coords to 0,0

        }

        public void Update(GameTime gameTime)
        {

            Vector2 moveVector = inputVector * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            X += moveVector.X;
            Y += moveVector.Y;

            CheckCollision();
        }

        public void CheckCollision()
        {
            if (X < character.X + Character.Size &&
                X + Size > character.X &&
                Y < character.Y + Character.Size &&
                Y + Size > character.Y)
            {
                Debug.Write("Collision Detected");
            }

        }



        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawRectangle(new RectangleF(X - Size / 2, Y - Size / 2, Size, Size), Color.Black, thickness: 3); //google enums

        }






    }
}
