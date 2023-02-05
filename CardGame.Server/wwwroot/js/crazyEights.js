let gameConnection = new signalR.HubConnectionBuilder().withUrl("/CrazyEightsHub").build();

gameConnection.start().then(function () {
    //the connection has been established activate the send message button.
    console.log('connected to the crazy eights hub.');
    gameConnection
        .invoke("AddPlayer")
}).catch(function (err)
{
    return console.error(err.toString());
});
gameConnection.on("displayConnectionId", function(connectionId) { displayConnectionId(connectionId)});
gameConnection.on("cardPlayed", cardPlayed());
gameConnection.on("deal", function(hand){dealCards(hand)});

document.getElementById("dealButton")
    .addEventListener("click", function (event) {
        gameConnection
            .invoke("DealCards")
            .catch(
                function (err) {
                    return console.error(err.toString());
                });
        event.preventDefault();
    });
function displayConnectionId(connectionId){
    $("#lblConnectionID").text(connectionId);
}
function cardPlayed(){
    
}
function dealCards(cards){
    $(cards).each(function() {
        $("#your-hand").append(BuildCard(this));
    });
}
function BuildCard(c){
    let cardString =document.createElement("label");
    cardString.textContent = c.rank + " of " + c.suit;
    return cardString;
}

