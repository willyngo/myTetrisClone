using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Tetris;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <authors>
    /// Seaim Khan and William Ngo
    /// </authors>
    class ShapeSprite : DrawableGameComponent
    {
        IShape shape;
        //for move down frequency
        Score score;
        int counterMoveDown;

        //For keyboard input
        KeyboardState oldState;
        int threshold;
        int counter;

        Game game;
        SpriteBatch spriteBatch;

        //To render
        Texture2D filledBlock;

        private IBoard board;

        public ShapeSprite(Game game, IBoard board, Score score) : base(game)
        {
            this.game = game;
            this.score = score;
            this.shape = board.Shape;
            this.board = board;
        }

        public override void Initialize() 
        {
            oldState = Keyboard.GetState();
            this.threshold = 10;
            base.Initialize();
        }

        protected override void LoadContent() 
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            filledBlock = game.Content.Load<Texture2D>("FilledBlock"); 
            base.LoadContent();
        }

        public override void Update(GameTime gameTime) 
        {
            double dropDelay = (11 - score.Level) * 3; 
            checkInput();
            shape = board.Shape;

            if (counterMoveDown > dropDelay)
            {
                shape.MoveDown();
                counterMoveDown = 0;
            }
            else
                counterMoveDown++;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) 
        {
            spriteBatch.Begin();
            for (int i = 0; i < shape.Length; i++)
            {
                spriteBatch.Draw(filledBlock, new Vector2(shape[i].Position.X * 19,
                                shape[i].Position.Y * 19), shape[i].Colour);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void checkInput()
        {
            KeyboardState newState = Keyboard.GetState();

            //Right keypress

            if (newState.IsKeyDown(Keys.Right))
            {

                //If key is not being held down. 
                if (!oldState.IsKeyDown(Keys.Right)) 
                {
                    shape.MoveRight();
                    counter = 0;
                }

                //Key is being held down.
                else
                {
                    counter++;
                    if (counter > threshold)
                    {
                        shape.MoveRight();
                        counter = 0;
                    }
                }

            }

            //Left keypress 

            else if (newState.IsKeyDown(Keys.Left))
            {

                //If key is not being held down. 
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    shape.MoveLeft();
                    counter = 0;
                }

                //Key is being held down.
                else
                {
                    counter++;
                    if (counter > threshold)
                    {
                        shape.MoveLeft();
                        counter = 0;
                    }
                }
            }


            //Up keypress 

            else if (newState.IsKeyDown(Keys.Up))
            {

                //If key is not being held down. 
                if (!oldState.IsKeyDown(Keys.Up))
                {
                    shape.Rotate();
                    counter = 0;
                }

                //Key is being held down.
                else 
                {
                    counter++;
                    if (counter > threshold)
                    {
                        shape.Rotate();
                        counter = 0;
                    }
                }

            }


            //Down keypress
            else if (newState.IsKeyDown(Keys.Down))
            {

                //If key is not being held down. 
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    shape.MoveDown();
                    counter = 0; 
                }

                //Key is being held down.
                else 
                {
                    counter++;
                    if (counter > 2)
                    {
                        shape.MoveDown();
                        counter = 0;
                    }
                }
            }

            //Space keypress
            else if (newState.IsKeyDown(Keys.Space))
            {
                if (!oldState.IsKeyDown(Keys.Space))
                {
                    shape.Drop();
                    counter = 0; 
                }

            }

            oldState = newState;
        }
    }
}
