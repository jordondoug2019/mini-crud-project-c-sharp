// Grabs id from url query
let url_string = window.location.href;
let url = new URL(url_string);
let gameID = url.searchParams.get("gameid")

// function that pre populates the form fields
console.log(gameID);
fetch(`api/Games/${gameID}`)
.then(data=>data.json())
.then(resp=>{
    document.getElementById("header").innerHTML = `Currently Editing ${resp.gameName}`
    document.getElementById("name").value = resp.gameName;
    document.getElementById("genre").value = resp.gameGenre;
    document.getElementById("date").value = resp.dateReleased;
    document.getElementById("gsynopsis").value = resp.synopsis;
});
// function that allows user to edit instance in the DB
function editGame() 
{
    fetch(`api/Games/${gameID}/`, {
        method: "put",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            id: gameID,
            gameName: document.getElementById("name").value,
            gameGenre: document.getElementById("genre").value,
            dateReleased: document.getElementById("date").value,
            synopsis: document.getElementById("gsynopsis").value
        })        
    }) 
    .then(console.log("edited entry"))
        // .then(data=>data.json())
        // .then(res=>console.log(res))
}
