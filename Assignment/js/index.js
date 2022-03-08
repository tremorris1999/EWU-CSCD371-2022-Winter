//retrieve a joke from the joke API
axios({
    method: 'get',
    url: 'https://v2.jokeapi.dev/joke/Programming'
})
    .then(function (response) {
        console.log(response);
        console.log(response.data.joke)

        let jokeText = document.querySelector(".joke");
        jokeText.innerText = response.data.joke;
    })

    .catch(function (error) {
        console.log(error);

        let jokeError = document.querySelector(".error");
        jokeError.innerText = "Please try again in a few moments.";
    })

//add an event listener (click) to tell another joke
document.getElementsByClassName("jokecard_another").addEventListener("click", function () {
    axios({
        method: 'get',
        url: 'https://v2.jokeapi.dev/joke/Programming'
    })
        .then(function (response) {
            console.log(response);
            console.log(response.data.joke)

            let jokeText = document.querySelector(".joke");
            jokeText.innerText = response.data.joke;
        })

        .catch(function (error) {
            console.log(error);

            let jokeError = document.querySelector(".error");
            jokeError.innerText = "Please try again in a few moments.";
        })
});