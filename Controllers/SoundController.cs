using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;


namespace App05MonoGame.Controllers
{
    /// <summary>
    /// Sound Controller will manage any sounds or music in the game.
    /// </summary>
    /// <author>
    /// Andrei Cruceru
    /// </author>
    public static class SoundController
    {
        private static readonly Dictionary<string, Song> Songs =
            new Dictionary<string, Song>();

        private static readonly Dictionary<string, SoundEffect> SoundEffects = 
            new Dictionary<string, SoundEffect>();
        
        /// <summary>
        /// Load songs and sound effects.
        /// </summary>
        /// <param name="content"></param>
        public static void LoadContent(ContentManager content)
        {
            Songs.Add("Adventure",content.Load<Song>("Sounds/Adventures"));            

            SoundEffects.Add("Coin", content.Load<SoundEffect>("Sounds/Coins"));
            SoundEffects.Add("Flame", content.Load<SoundEffect>("Sounds/flame"));
        }
        /// <summary>
        /// Get a sound effect from the collection.
        /// </summary>
        /// <param name="effect">A string type key assigned to a sound effect.</param>
        /// <returns>A SoundEffect object assigned to the string key.</returns>
        public static SoundEffect GetSoundEffect(string effect)
        {
            return SoundEffects[effect];
        }
        /// <summary>
        /// Play a song
        /// </summary>
        /// <param name="song">A string type key assigned to a song.</param>
        public static void PlaySong(string song)
        {
            MediaPlayer.IsRepeating = true;

            MediaPlayer.Play(Songs[song]);
        }

        public static void PauseSong()
        {
            MediaPlayer.Pause();
        }

        public static void ResumeSong()
        {
            MediaPlayer.Resume();
        }
    }
}
