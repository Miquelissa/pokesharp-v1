using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Pokesharp.Util {
    static class MusicPlayer {

        static private MediaPlayer mediaPlayer = new MediaPlayer();

        static public void playMusic(string name) {
            mediaPlayer.Open(new Uri(@"../../Resources/Musics/" + name  + ".mp3", UriKind.Relative));
            mediaPlayer.Volume = 0.05;
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
        }
    }
}
