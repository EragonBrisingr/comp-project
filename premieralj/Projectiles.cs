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
        public float X { get; set; }
        public float Y { get; set; }

        public const float Speed = 250f;
        public const float Size = 20f;

        Vector2 inputVector;

        public float timeElapsed = 0f;
        public float timeAllowed = .5f;

        Character character;
        List<Enemy> enemies;

        public Projectiles(Character player, Vector2 shootDir, List<Enemy> enemies)
        {
            X = player.X;
            Y = player.Y;
            character = player;
            inputVector = new Vector2(shootDir.X, shootDir.Y); //creating new vector puts coords to 0,0
            this.enemies = enemies;
        }

        public void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 moveVector = inputVector * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            X += moveVector.X;
            Y += moveVector.Y;
            CheckCollision();
        }

        public void CheckCollision()
        {
            if (timeElapsed >= timeAllowed)
            {
                foreach (Enemy enemy in enemies)
                {
                    if (X < enemy.X + Enemy.Size &&
                        X + Size > enemy.X &&
                        Y < enemy.Y + Enemy.Size &&
                        Y + Size > enemy.Y)
                    {
                        Debug.Write("Bullet Collision Detected \t");
                        enemy.EnemyHealth--;
                        break; // Optional: break if you want to stop checking after the first collision
                    }
                }
                timeElapsed = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawRectangle(new RectangleF(X - Size / 2, Y - Size / 2, Size, Size), Color.Black, thickness: 3); //google enums

        }
    }
}
