//TODO: add setTimeout(function (), 4000) between setup and punchline

//retrieve a joke from the joke API
axios({
    method: 'get',
    url: 'https://v2.jokeapi.dev/joke/Programming'
})
    .then(function (response) {
        console.log(response);
        console.log(response.data.setup);
        console.log(response.data.delivery);

        let jokeText = document.querySelector(".jokecard_content");
        jokeText.innerText = response.data.setup;
        //TODO add timeout here
        joketext.innerText += '\n';
        jokeText.innerText += response.data.delivery;
    })

    .catch(function (error) {
        console.log(error);

        let jokeError = document.querySelector(".jokecard_content");
        jokeError.innerText = "Please try again in a few moments.";
        //TODO add timeout here
    })

//add an event listener (click) to tell another joke
document.getElementsByClassName("jokecard_another").addEventListener("click", function () {
    axios({
        method: 'get',
        url: 'https://v2.jokeapi.dev/joke/Programming'
    })
        .then(function (response) {
            console.log(response);
            console.log(response.data.setup);
            console.log(response.data.delivery);

            let jokeText = document.querySelector(".jokecard_content");
            jokeText.innerText = response.data.setup;
            //TODO add timeout
            joketext.innerText += '\n';
            jokeText.innerText += response.data.delivery;
        })

        .catch(function (error) {
            console.log(error);

            let jokeError = document.querySelector(".jokecard_content");
            jokeError.innerText = "Please try again in a few moments.";
            //TODO add timeout
        })
});
