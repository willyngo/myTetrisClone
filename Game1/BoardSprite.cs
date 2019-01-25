using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tetris;

namespace Game1
{
    /// <authors>
    /// Seaim Khan and William Ngo
    /// </authors>
    class BoardSprite : DrawableGameComponent
    {
        IBoard board;
        Game game;
        SpriteBatch spriteBatch;
        //To render
        Texture2D emptyBlock;
        Texture2D filledBlock;

        public BoardSprite(Game game, IBoard board) : base(game)
        {
            this.game = game;
            this.board = board;
        }


        public override void Initialize() 
        {
            base.Initialize();
        }

        protected override void LoadContent() 
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            emptyBlock = game.Content.Load<Texture2D>("EmptyBlock"); 
            filledBlock = game.Content.Load<Texture2D>("FilledBlock"); 
            base.LoadContent();
        }

        public override void Update(GameTime gameTime) 
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) 
        {
            spriteBatch.Begin();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(board[i,j] == Color.Transparent)
                        spriteBatch.Draw(emptyBlock, new Vector2(j* 19, i* 19), Color.White);
                    else
                        spriteBatch.Draw(filledBlock, new Vector2(j * 19, i * 19), board[i, j]);
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
