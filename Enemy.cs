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
    public class Enemy
    {

        Character character;

        public float Y {  get; set; }

        public float X { get; set; }
        

        public const float Speed = 10f;
        public const float Size = 70f;
        private Vector2 enemyPosition;
        private Vector2 playerPosition;
        private Vector2 direction;

        protected int state;

        public float timeElapsed = 0f;
        public float timeAllowed = 1f;

        public Enemy(float x, float y, Character player)
        {
            character = player;
            X = x;
            Y = y;
        }

        public void Update(GameTime gameTime)
        {

            playerPosition = new Vector2(character.X, character.Y);
            enemyPosition = new Vector2(X, Y);

            direction = playerPosition - enemyPosition;

            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (direction != Vector2.Zero)
            {
                direction = Vector2.Normalize(direction);
            }

            Vector2 moveVector = direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            X += moveVector.X;
            Y += moveVector.Y;

            CheckCollision();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(new RectangleF(X - Size / 2, Y - Size / 2, Size, Size), Color.Red, thickness: 5);
        }

        public void CheckCollision()
        {
            if (timeElapsed >= timeAllowed)
            {
                if (X < character.X + Character.Size &&
                    X + Size > character.X &&
                    Y < character.Y + Character.Size &&
                    Y + Size > character.Y)
                {
                    Debug.Write("Enemy Collision Detected \t");
                    character.Health --;
                }
                timeElapsed = 0;
            }
        }

    }
}
