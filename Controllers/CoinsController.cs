using App05MonoGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace App05MonoGame.Controllers
{
    public enum CoinColours
    {
        copper = 100,
        Silver = 200,
        Gold = 500
    }

    /// <summary>
    /// This class creates a list of coins which
    /// can be updated and drawn and checked for
    /// collisions with the player sprite
    /// </summary>
    /// <authors>
    /// Derek Peacock & Andrei Cruceru
    /// </authors>
    public class CoinsController
    {
        private AnimatedSprite coinTemplate;

        private Animation animation;

        private Random generator = new Random();

        private SoundEffect coinEffect;

        private readonly List<AnimatedSprite> Coins; 
        
        private float maxTime = 2f;

        private float timer;

        public CoinsController()
        {
            Coins = new List<AnimatedSprite>();
        }
        /// <summary>
        /// Create an animated sprite of a copper coin
        /// which could be collected by the player for a score
        /// </summary>
        public void CreateCoin(GraphicsDevice graphics, Texture2D coinSheet)
        {
            coinEffect = SoundController.GetSoundEffect("Coin");
            animation = new Animation("coin", coinSheet, 8);

            AnimatedSprite coin = new AnimatedSprite()
            {
                Animation = animation,
                Image = animation.SetMainFrame(graphics),
                Scale = 2.0f,
                Position = new Vector2(600, 100),
                Speed = 0,
            };

            coinTemplate = coin;
            Coins.Add(coin);
        }

        public void HasCollided(AnimatedPlayer player)
        {
            foreach (AnimatedSprite coin in Coins)
            {
                if (coin.HasCollided(player) && coin.IsAlive)
                {
                    coinEffect.Play();

                    coin.IsActive = false;
                    coin.IsAlive = false;
                    coin.IsVisible = false;
                }
            }           
        }

        /// <summary>
        /// need to set a timer going 2 seconds 
        /// decrease timer until it 0 and that 0 create new coin
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            foreach(AnimatedSprite coin in Coins)
            {
                coin.Update(gameTime);
            }
            timer = timer - (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0) 
            {
                timer = maxTime;
                AnimatedSprite coin = new AnimatedSprite();
                coin.Animation = animation;
                coin.Image = coinTemplate.Image;
                coin.Speed = coinTemplate.Speed;
                coin.Scale = coinTemplate.Scale;

                int x = generator.Next(800) + 100;
                int y = generator.Next(500) + 100;

                coin.Position = new Vector2(x,y);

                Coins.Add(coin);

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (AnimatedSprite coin in Coins)
            {
                coin.Draw(spriteBatch);
            }
        }
    }
}
