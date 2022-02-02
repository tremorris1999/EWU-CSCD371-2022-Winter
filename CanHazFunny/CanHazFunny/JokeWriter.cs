using System;
using System.IO;

namespace CanHazFunny
{
    public class JokeWriter : IWritable
    {
        /* NOTE: Instructions seemed kind of unclear about whether Console.WriteLine() was a REQUIREMENT
         * for the implementation of the output interface, so I left this one open ended. It will use
         * Console.Out as the TextWriter in the tests, however, so it is effectively invoking Console.WriteLine(). Hope
         * this is okay!
         */
        public TextWriter? TextWriter { get; private set; }

        public void Write(string output)
        {
            if(TextWriter == null)
                throw new InvalidOperationException($"{nameof(TextWriter)} property is null.");

            TextWriter.WriteLine(output);
        }

        public void SetTextWriter(TextWriter textWriter)
        {
            TextWriter = textWriter;
        }
    }
}