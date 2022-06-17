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
        $o++;
        $i = 0;
        $pogrow=mysqli_query($conn, "SELECT * FROM testquestions WHERE testid=".$row['testid']."");
        echo "'" . $row['testid'] . "'" . ": {";
        while ($_ROW = $pogrow->fetch_array()){
            if ($i != $pogrow->num_rows) {  
            echo $_ROW['taskid'] . " : " . $_ROW['question'] . ",";
            $i++;
            }
                        
            else 
            {
            echo $_ROW['taskid'] . " : " . $_ROW['question'];
            } 
        }
        if ($o < $result->num_rows){
            echo "},";
    }
    else{
        echo "}";
    }
}
}

?>