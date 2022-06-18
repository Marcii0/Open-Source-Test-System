<?php

$teachername = $_POST['teachername'];
$teacherid = $_POST['teacherid'];

$servername = "localhost";
$database = "teachers";
$username = "root";
$password="";
$conn = mysqli_connect($servername, $username, $password, $database);

$result=mysqli_query($conn, "SELECT * FROM tests WHERE teacherid=".$teacherid."");

if ($result->num_rows > 0)
{
    $o = 0;
    while ($row = $result->fetch_array())
    {
        echo "{ID : ".$row['testid'].",\nTest Name: ".$row['testname'].",\nNumberOfTasks: ".$row['numberoftasks']."}";
    }
}

?>