//retrieve a joke from the joke API
axios({
    method: 'get',
    url: 'https://v2.jokeapi.dev/joke/Programming'
})
    .then(function (response) {
        console.log(response);

    })

    .catch(function (error) {
        console.log(error)

        let jokeText = document.
    })
//add an event listener (click) to tell another joke