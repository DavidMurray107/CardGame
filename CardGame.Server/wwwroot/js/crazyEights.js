class Card {
     Rank;
     Suit;
     FriendlySuit; 
     Value;
     constructor(rank, suit, friendlySuit, value) {
         this.Rank = rank;
         this.Suit = suit;
         this.FriendlySuit = friendlySuit;
         this.Value = value;
     }
}
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
    try {
        let hand = $("#your-hand");
        $(hand).html("");
        for (let i = 0; i < $(cards).length; i++) {
            let c = new Card(cards[i].rank, cards[i].suit, cards[i].friendlySuit, cards[i].value)
            $(hand).append(BuildCard(c));
        }
    }
    catch(e){
        console.error(`an issue occured while dealing: ${e}` );
    }
}
function BuildCard(c){
    let cardImg=document.createElement("img");
    cardImg.src = '/api/Card/'+c.Value+c.FriendlySuit.substring(0,1)
    cardImg.className = "playing-card";
    return cardImg;
}

