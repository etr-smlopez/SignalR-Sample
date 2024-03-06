"use stict";

var connection = new signalR.HubConnectionBuilder().withUrl("/updateHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveUpdate", function (message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = 'Awit';
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    var message = 'Awit';
    connection.invoke("SendUpdate", message).catch(function (err) {
        return console.error(err.toString());
    });
}).catch(function (err) {
    return console.error(err.toString());
});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.tostring());
//});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = 'Awit';
    connection.invoke("SendUpdate", message).catch(function (err) {
        return console.error(err.tostring());
    });
    event.preventDefault();
});