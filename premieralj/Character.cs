using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using premiertest;

namespace premiertest
{
    public class Character
    {
        public float X { get; set; }
        public float Y { get; set; }

        public const float Speed = 150f;
        public const float Size = 80f;

        public float timeElapsed = 0f;
        public float timeAllowed = 0.5f;


        public List<Projectiles> projectilesList;
        public List<Enemy> enemyList;

        public int Health { get; set; } = 4;

        public Character(float x, float y)
        {
            (X, Y) = (x, y);
            projectilesList = new List<Projectiles>();
            enemyList = new List<Enemy>();

        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            Vector2 inputVector = new Vector2(); //creating new vector puts coords to 0,0

            Vector2 shootVector = new Vector2();

            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //movement
            if (keyState.IsKeyDown(Keys.D))
            {
                inputVector.X = 1;

            }
            else if (keyState.IsKeyDown(Keys.A))
            {
                inputVector.X = -1;
            }

            if (keyState.IsKeyDown(Keys.W))
            {
                inputVector.Y = -1;
            }
            else if (keyState.IsKeyDown(Keys.S))
            {
                inputVector.Y = 1;
            }

            //shooting directions
            if (keyState.IsKeyDown(Keys.Right))
            {
                shootVector.X = 1;
                ShootBullet(shootVector);
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                shootVector.X = -1;
                ShootBullet(shootVector);
            }
            else if (keyState.IsKeyDown(Keys.Up))
            {
                shootVector.Y = -1;

                ShootBullet(shootVector);
            }
            else if (keyState.IsKeyDown(Keys.Down))
            {
                shootVector.Y = 1;

                ShootBullet(shootVector);
            }
            //normalizing vectors
            if (inputVector.Length() != 0)
            {
                inputVector = Vector2.Normalize(inputVector);
            }
            if (shootVector.Length() != 0)
            {
                shootVector = Vector2.Normalize(shootVector);
            }
            //(1, 1) -> (1/sqrt(2), 1/sqrt(2) ) 



            Vector2 moveVector = inputVector * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            X += moveVector.X;
            Y += moveVector.Y;
            foreach (var projectile in projectilesList)
            {
                projectile.Update(gameTime);
            }

        }



        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawRectangle(new RectangleF(X - Size / 2, Y - Size / 2, Size, Size), Color.DarkGray, thickness: 5); //google enums

            foreach (var projectile in projectilesList)
            {
                projectile.Draw(spritebatch);
            }

        }


        public void AddEnemy(Enemy enemy)
        {
            enemyList.Add(enemy);
        }

        public void ShootBullet(Vector2 shooter)
        {

            if (timeElapsed >= timeAllowed)
            {
                projectilesList.Add(new Projectiles(this, shooter, enemyList));
                timeElapsed = 0;
            }

        }



    }
}
