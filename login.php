<?php
session_start();

// checking if user is logged in
if(isset($_SESSION['user_id'])) {
    header("Location: index.php"); 
    exit();
}

// checking if login form is posted
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    require('db_connection.php');

    // checking connection with database
    if (!$connection) {
        die("Błąd połączenia z bazą danych: " . mysqli_connect_error());
    }
    

    // getting data from login form
    $username = $_POST['username'];
    $password = $_POST['password'];

    // SQL injection protection
    $username = mysqli_real_escape_string($connection, $username);

    // validating login data
    $query = "SELECT id, username, password FROM users WHERE username = '$username'";
    $result = mysqli_query($connection, $query);

    if ($result && mysqli_num_rows($result) > 0) {
        $row = mysqli_fetch_assoc($result);
        // checking password
        if ($password === $row['password']) {
            
            $_SESSION['user_id'] = $row['id'];
            header("Location: index.php");
            exit();
        } else {
            $error = "Nieprawidłowe hasło!";
        }
    } else {
        $error = "Nieprawidłowa nazwa użytkownika!";
    }
    }
?>
<!DOCTYPE html>
<html>
<head>
    <title>Logowanie</title>
    <link rel="stylesheet" href="zgapiony.css" type="text/css">
    <link rel="stylesheet" href="kot.png" type="image/x-icon">
</head>
<body>
    <h2>Logowanie</h2>
    <?php if(isset($error)) { ?>
        <p style="color: red;"><?php echo $error; ?></p>
    <?php } ?>
    <form method="POST" action="">
        <label>Nazwa użytkownika:</label><br>
        <input type="text" name="username" required><br><br>
        <label>Hasło:</label><br>
        <input type="password" name="password" required><br><br>
        <input type="submit" value="Zaloguj">
    </form>
</body>
</html>
