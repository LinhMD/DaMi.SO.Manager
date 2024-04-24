"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/notification").build();

// //Disable the send button until connection is established.
// document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});

connection.on("notify", function (notification) {
    console.log(notification);
    var wrapper = document.createElement('div');
    wrapper.innerHTML = `<li class="media dropdown-item active">
        <div class="media-body">
            <a href="/notification/${notification.rowUniqueId}">
                <p class="text-messageType">
                    ${notification.message}
                </p>
            </a>
        </div>
        <span class="notify-time">${notification.createdDate}</span>
    </li>`
    var li = wrapper.firstChild;
    $("#notifications").prepend(li);


    wrapper = document.createElement('div');
    wrapper.classList.add('pulse-css');
    $('#notification-a').append(wrapper);
    var titleChange = setInterval(function () {
        var title = document.title;
        document.title = (title == "DaMi" ? "Có thông báo" : "DaMi");
    }, 3000);
    titleChange.start();
    $('#notification-a').click(() => {
        clearInterval(titleChange);
        document.title = "DaMi";
        $('.pulse-css').remove()
    });
    toastr.info(notification.message || "Có thông báo");
});
connection.start()
// .then(function () {
//     document.getElementById("sendButton").disabled = false;
// }).catch(function (err) {
//     return console.error(err);
// });

// document.getElementById("sendButton").addEventListener("click", function (event) {
//     var user = document.getElementById("userInput").value;
//     var message = document.getElementById("messageInput").value;
//     connection.invoke("SendMessage", user, message).catch(function (err) {
//         return console.error(err.toString());
//     });
//     event.preventDefault();
// });