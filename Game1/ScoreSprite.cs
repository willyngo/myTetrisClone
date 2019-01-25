using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tetris;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    /// <authors>
    /// Seaim Khan and William Ngo
    /// </authors>
    class ScoreSprite : DrawableGameComponent 
    {
        Score score;
        Game game;
        SpriteBatch spriteBatch;
        SpriteFont font;

        public ScoreSprite(Game game, Score score) : base(game)
        {
            this.game = game;
            this.score = score;
        }

        //Methods

        public override void Initialize() 
        {
            base.Initialize();
        }

        protected override void LoadContent() 
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = game.Content.Load<SpriteFont>("scoreFont"); 
            base.LoadContent();
        }

        public override void Update(GameTime gameTime) 
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) 
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Score: " + score.GameScore, new Vector2(200,0), Color.White);
            spriteBatch.DrawString(font, "Current Level: " + score.Level, new Vector2(200, 20), Color.White);
            spriteBatch.DrawString(font, "Lines Cleared:" + score.Lines, new Vector2(200, 40), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
