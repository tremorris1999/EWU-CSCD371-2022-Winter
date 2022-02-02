using System;

namespace CanHazFunny
{
    public class Jester
    {
        private IJokable _JokeService;
        private IWritable _Output;

        public Jester(IJokable? jokeService, IWritable? output)
        {
            if(jokeService == null)
                throw new ArgumentNullException(nameof(jokeService));
            if(output == null)
                throw new ArgumentNullException(nameof(output));

            _JokeService = jokeService;
            _Output = output;
        }

        public void TellJoke()
        {
            string joke = _JokeService.GetJoke();

            while (joke.ToLower().Contains("Chuck Norris".ToLower()))
            {
                joke = _JokeService.GetJoke();
            }

            _Output.Write(joke);
        }
    }
}