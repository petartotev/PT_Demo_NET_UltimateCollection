using Personal.Async.Pluralsight.Article._1.TPL.Enums;
using static Personal.Async.Pluralsight.Article._1.TPL.Sample;

namespace Personal.Async.Pluralsight.Article._1.TPL
{
    // Define a note as a frequency (tone) and the amount of
    // time (duration) the note plays.
    public struct Note
    {
        Tone toneVal;
        Duration durVal;

        // Define a constructor to create a specific note.
        public Note(Tone frequency, Duration time)
        {
            toneVal = frequency;
            durVal = time;
        }

        // Define properties to return the note's tone and duration.
        public Tone NoteTone { get { return toneVal; } }
        public Duration NoteDuration { get { return durVal; } }
    }
}
