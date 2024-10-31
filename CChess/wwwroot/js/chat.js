//"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

////Disable the send button until connection is established.
//document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
//    var li = document.createElement("li");
//    document.getElementById("messagesList").appendChild(li);
//    // We can assign user-supplied strings to an element's textContent because it
//    // is not interpreted as markup. If you're assigning in any other way, you
//    // should be aware of possible script injection concerns.
//    li.textContent = `${user} says ${message}`;
//});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});

"use strict";

// Wait for the DOM to fully load before executing the script
document.addEventListener("DOMContentLoaded", function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    // Disable the send button until the connection is established
    document.getElementById("sendButton").disabled = true;

    connection.on("ReceiveMessage", function (user, message) {
        var li = document.createElement("li");
        document.getElementById("messagesList").appendChild(li);
        // Assign user-supplied strings to an element's textContent
        li.textContent = `${user} says: ${message}`;
    });

    connection.start().then(function () {
        // Enable the send button once connected
        document.getElementById("sendButton").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });

    document.getElementById("sendButton").addEventListener("click", function (event) {
        var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;
        // Ensure user and message are not empty
        if (user && message) {
            connection.invoke("SendMessage", user, message).catch(function (err) {
                return console.error(err.toString());
            });
            // Clear message input after sending
            document.getElementById("messageInput").value = '';
        } else {
            alert("Please enter both user and message.");
        }
        event.preventDefault();
    });
});
