using System.Media;
using System.Threading;

namespace Speedtronome
{
    class Metronome
    {
        private double period;      // Metronome period (in ms)
        private SoundPlayer tone;   // The .wav to play for the tick
        private Timer timer;        // Repeating timer that plays the tone

        public Metronome(double bpm, string soundFilePath = "2.wav")
        {
            period = 60.0 * 1000 / bpm;
            tone = new SoundPlayer(soundFilePath);
            tone.Load();
            timer = null;
        }

        public Metronome(int frames, double framerate, string soundFilePath = "2.wav")
        {
            period = 1000 * frames / framerate;
            tone = new SoundPlayer(soundFilePath);
            tone.Load();
            timer = null;
        }

        public void Oscillate()
        {
            timer = new Timer(Tick, null, 0, (int)period);
        }

        public void Halt()
        {
            if (timer != null)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer = null;
            }
        }

        private void Tick(object _)
        {
            tone.Play();
        }
    }
}
