var connection = new signalR.HubConnectionBuilder().withUrl("/ConnectedHubs").build();

connection.on("ReceiveMessage", function (user, message) {
    $("#userInput").val('');
    $("#messageInput").val('');
    var li = $("<li>").text(`${user} says ${message}`);
    $("#messageList").append(li);
});

connection.on("UpdateUserList", function (users) {
    var userList = $("#userList");
    userList.empty(); // Clear the existing list
    users.forEach(function (user) {
        userList.append($("<li>").text(user));
    });
});

connection.start().then(function () {
    $("button[type='submit']").prop("disabled", false);
}).catch(function (error) {
    console.log(error.toString());
});

$("#messageForm").on("submit", function (event) {
    event.preventDefault();
    var user = $("#userInput").val();
    var message = $("#messageInput").val();

    connection.invoke("SendMessage", user, message).catch(function (error) {
        console.log(error.toString());
    });
});
