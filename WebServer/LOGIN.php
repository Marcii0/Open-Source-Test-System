<?php 
$time_start = microtime(true); 
$teachername = $_POST['username'];
$teacherpassword = $_POST['password'];

$servername = "localhost";
$database = "teachers";
$username = "root";
$password="";
$conn = mysqli_connect($servername, $username, $password, $database);
$pathToFile = 'logs.log';
$result=mysqli_query($conn, "SELECT * FROM teachercredentials WHERE teachername='".$teachername."' AND teacherpassword='".$teacherpassword."';");
if ($result->num_rows > 0 ){
while ($row = $result->fetch_array())
{
$data = $row['teachername']." has logged in at ".date("Y-m-d H:i:s")." This took ".(microtime(true) - $time_start)." MS.\n";
echo $row['teachername']."\n".$row['teacherpassword']."\n".$row['id'];
file_put_contents($pathToFile, $data, FILE_APPEND);
}}
else {
    echo "Your username or password is incorrect!";
}
?>