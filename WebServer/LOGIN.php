<?php 

$teachername = $_POST['username'];
$teacherpassword = $_POST['password'];

$servername = "localhost";
$database = "teachers";
$username = "root";
$password="";
$conn = mysqli_connect($servername, $username, $password, $database);

$result=mysqli_query($conn, "SELECT * FROM teachercredentials WHERE teachername='".$teachername."' AND teacherpassword='".$teacherpassword."'");
if ($result->num_rows > 0 ){
while ($row = $result->fetch_array())
{
echo $row['teachername']."\n".$row['teacherpassword']."\n".$row['id'];
}}
else {
    echo "Your username or password is incorrect!";
}
?>