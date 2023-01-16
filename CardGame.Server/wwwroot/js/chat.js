"use strict";

//open a new connection.
let connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    let li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    //text content is not interpreted as markup so assigning a user supplied string is acceptable.
    li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    //the connection has been established activate the send message button.
    document.getElementById("sendButton").disabled = false;
}).catch(function (err)
{
    return console.error(err.toString());
});

document.getElementById("sendButton")
    .addEventListener("click", function (event) {
        let user = document.getElementById("userInput").value;
        let message = document.getElementById("messageInput").value;
        connection
            .invoke("SendMessage", user, message)
            .catch(
                function (err) {
                    return console.error(err.toString());
                });
        event.preventDefault();
    });