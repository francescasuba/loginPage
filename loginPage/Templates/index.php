<?php
    if($_SERVER['REQUEST_METHOD'] == 'POST') {
        /*Creating variables*/
        $username = $_POST["username"];
        $password = $_POST["password"];
        $email = $_POST["email"];


        $dbhost = "localhost"; /*most of the time it's localhost*/
        $username = "yourusername";
        $password = "yourpassword";
        $dbname = "mydatabase";

        $mysql = mysqli_connect($dbhost, $username, $password, $dbname); //It connects
        $query = "INSERT INTO yourtable (username,password,email) VALUES $username, $password, $email";
        mysqli_query($mysql, $query);
    }
?>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Login Page</title>
</head>

<script>
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    var email = document.getElementById("email").value;

    $.ajax({
        type: "GET",
        url: "http://hostname/projectfolder/webservicename.php?callback=jsondata&web_name=" + name + "&web_address=" + address + "&web_age=" + age,
        crossDomain: true,
        dataType: 'jsonp',
        success: function jsondata(data) {

            var parsedata = JSON.parse(JSON.stringify(data));
            var logindata = parsedata["Status"];

            if ("sucess" == logindata) {
                alert("success");
            }
            else {
                alert("failed");
            }
        }
    });
</script>

<body>
    <form action="../Controllers/login" method="post">
        <label for="email">Email:</label><br />
        <input type="text" id="email" name="email" /><br />
        <label for="password">Password:</label><br />
        <input type="text" id="password" name="password" /><br />
        <input type="submit" />
    </form>
</body>
</html>