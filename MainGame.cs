using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace premiertest
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Character character;
        private Enemy enemy;
        private Projectiles projectiles;
        private HealthBar health;
        //private List<Entity> entityList;
        //private List<CollisionEntity> collisionEntityList;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here


            // Define health bar position
            


            character = new Character(200, 200);
            health = new HealthBar(character);
            enemy = new Enemy(300, 300, character);
            character.AddEnemy(enemy);

            //collisionEntityList.Add(character);
            //entityList.Add(new HealthBar(character));
            // ...

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            character.Update(gameTime);
            enemy.Update(gameTime);
            health.Update(gameTime);

            //foreach(Entity e in entityList){
            // e.Update(gameTime);
            //}

            //for (int i = 0; i < collisionEntityList.Length(); i++){
            //  for (int j = i+1; j < collisionEntityList.Length(); j ++) {
            //    RectangleF c1 = collisionEntityList[i].GetHitbox();
            //    RectangleF c2 = collisionEntityList[j].GetHitbox();
            //    if (c1.Intersects(c2)) { 
            //        collisionEntityList[i].OnCollision(collisionEntityList[j]);
            //        collisionEntityList[j].OnCollision(collisionEntityList[i]);
            //    }
            //}


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            character.Draw(_spriteBatch);
            enemy.Draw(_spriteBatch);
            health.Draw(_spriteBatch);
            

            //foreach(Entity e in entityList){
            // e.Draw(_spriteBatch);
            //}

            //foreach(CollisionE ce in collisionEntityList){
            // ce.Draw(_spriteBatch);
            //}

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
