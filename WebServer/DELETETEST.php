<?php

$password = $_POST['password'];
$testid = $_POST['testid'];

$servername = "localhost";
$database = "teachers";
$username = "root";
$password="";
$conn = mysqli_connect($servername, $username, $password, $database);

$result = mysqli_query($conn, "SELECT * FROM teachercredentials WHERE teacherpassword='".$password"'");

if ($result->num_rows > 0)
{
    mysqli_query($conn, "DELETE FROM tests WHERE testid=".$testid"");
    mysqli_query($conn, "DELETE FROM testquestions WHERE testid=".$testid"");
    echo "Success";
}
else
{
    echo "Failure";
}






?>