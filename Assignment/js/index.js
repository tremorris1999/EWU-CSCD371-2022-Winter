function getJoke() {
    var setup = document.getElementById("setup");
    var punchline = document.getElementById("punchline");
    axios.get("https://v2.jokeapi.dev/joke/Programming")
        .then((response) => {
            punchline.innerHTML = "";
            if (response.data.type == "single")
                setup.innerHTML = response.data.joke;
            else {
                setup.innerHTML = response.data.setup;
                setTimeout((punchline) => document.getElementById("punchline").innerHTML = punchline, 4000, response.data.delivery);
            }
        })
        .catch(function(error) {
            setup.innerHTML = "Unable to reach the joke service.";
            punchline.innerHTML = "Perhaps YOU are the joke? (also obligatory 'try again in a few moments'";
        })
}

function showMenu() {
    var menu = document.getElementById("menu");
    var opacity;
    if (menu.style.visibility != "visible") {
        menu.classList.toggle("show");
    } else {
        menu.classList.toggle("show");
    }
}

function destroyEverything() {
    document.getElementById("body").innerHTML = "";

}

/**
 * NOTE: Calling getJoke after reverseAll will give you a non reversed joke on the reversed page.
 * Calling reverseAll after you have the mismatched order page and joke, will yield the 
 * non-reversed page and a reversed joke. This could be called a bug, but I prefer the term "feature".
 */
function reverseAll() {
    var elements = document.querySelectorAll('p, button, h1, h2, span');
    var preserveHamburger = document.getElementById("hamburger").outerHTML;
    for (let e of elements)
        e.innerHTML = e.textContent.split('').reverse().join('');

    document.getElementById("menu_btn").innerHTML += " " + preserveHamburger;
}

function redirectToLog() {
    window.location.href = "https://youtu.be/dQw4w9WgXcQ";
}

function alertUser() {
    var awaken = "THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THERE ARE BUGS UNDER YOUR SKIN GET THEM OUT THE FOG IS COMING THE FOG IS COMING";
    alert(awaken.concat(awaken.concat(awaken.concat(awaken))));
}