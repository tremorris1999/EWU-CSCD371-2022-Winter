using System;

namespace CanHazFunny
{
    public class Jester
    {
        private readonly IJokable _jokeService;
        private readonly IWritable _output;

        public Jester(IJokable? jokeService, IWritable? output)
        {
            if(jokeService == null)
                throw new ArgumentNullException(nameof(jokeService));
            if(output == null)
                throw new ArgumentNullException(nameof(output));

            _jokeService = jokeService;
            _output = output;
        }

        public void TellJoke()
        {
            string joke = _jokeService.GetJoke();

            while (joke.ToLower().Contains("Chuck Norris".ToLower()))
            {
                joke = _jokeService.GetJoke();
            }

            _output.Write(joke);
        }
    }
}