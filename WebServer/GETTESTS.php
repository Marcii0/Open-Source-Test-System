<?php 
$teachername = $_POST['teachername'];
$teacherid = $_POST['teacherid'];

$servername = "localhost";
$database = "teachers";
$username = "root";
$password="";
$conn = mysqli_connect($servername, $username, $password, $database);
$pathToFile = 'logs.log';
$result=mysqli_query($conn, "SELECT * FROM tests WHERE teacherid='".$teacherid."';");
if ($result->num_rows > 0 ){
while ($row = $result->fetch_array())
{
$test = new stdClass();
$test->testname = $row['testname'];
$test->testid = $row['testid'];
$test->teacherid = $row['teacherid'];
$test->numberoftasks = $row['numberoftasks'];
$data = $teachername." has requested ".$result->num_rows." tests\n";
$testjson = json_encode($test);
echo $testjson;
file_put_contents($pathToFile, $data, FILE_APPEND);
}}
else
{
    echo $teacherid.":PP_TwistSit:";
}
?>