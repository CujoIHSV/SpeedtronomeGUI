using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Speedtronome
{
    class Metronome
    {
        private double period;      // Metronome period (in ms)
        private SoundPlayer tone;   // The .wav to play for the tick

        private static readonly SoundPlayer defaultTone = new SoundPlayer("2.wav");

        public Metronome(double bpm)
        {
            period = 60.0 * 1000 / bpm;
            tone = defaultTone; // DEFAULT ONLY
            tone.Load();
        }

        public Metronome(int frames)
        {
            period = 1000 * frames / 60.098814;
            tone = defaultTone; // DEFAULT ONLY
            tone.Load();
        }

        public void Oscillate()
        {
            Timer timer = new Timer(Tick, null, 0, (int)period);
        }

        private void Tick(object _)
        {
            tone.Play();
        }
    }
}
