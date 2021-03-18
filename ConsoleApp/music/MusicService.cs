using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Reflection;

namespace ConsoleApp.music
{
    public class MusicService
    {
        public static void PlayMusic()
        {
            SoundPlayer player = new SoundPlayer();

            string resourcesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
            string filePath = Path.Combine(resourcesPath, "test.wav");
            player.SoundLocation = filePath;

            player.PlaySync();
        }
    }
}



