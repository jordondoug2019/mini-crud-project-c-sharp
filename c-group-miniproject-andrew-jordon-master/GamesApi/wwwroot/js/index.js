console.log("Test")
// Function to add an instance to the Game Model 
function addGame() 
{
    fetch("api/Games", {
        method: "post",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            gameName: document.getElementById("name").value,
            gameGenre: document.getElementById("genre").value,
            dateReleased: document.getElementById("date").value,
            synopsis: document.getElementById("gsynopsis").value

        })
    }) 
    .then(console.log("added entry"))
        // .then(data=>data.json())
        // .then(res=>console.log(res))
}
// fetch that pulls each instance from the DB and populates the list
fetch("api/Games") 
.then(data=>data.json())
// .then(data=>console.log(data))
.then(res=> res.map((eachGame)=>{
    let gameList = document.getElementById("gameList")
    let list_element= document.createElement("li")
    let link_element= document.createElement("a")
    let editBtn= document.createElement("button")
    let delBtn = document.createElement("button")
    editBtn.innerText="Edit"
    delBtn.innerText="Delete"
    link_element.setAttribute("href", `api/Games/${eachGame.id}`)
    delBtn.setAttribute("onclick", `deleteGames(${eachGame.id})`)
    editBtn.setAttribute("onclick", `window.location.href = "edit.html?gameid=${eachGame.id}"`)
    
    
    link_element.innerHTML=`${eachGame.gameName} ${eachGame.gameGenre} `
    // list_element.innerHTML=`${link_element} ${editBtn} ${delBtn}`
    list_element.append(link_element)
    list_element.append(editBtn)
    list_element.append(delBtn)
    gameList.append(list_element)
}))

function deleteGames(gameID){
    fetch(`api/Games/${gameID}/`,{method: "delete"})
    .then(console.log("game deleted"))
}
