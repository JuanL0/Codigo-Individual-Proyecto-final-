<?php

$dbname = 'UnityDB';
$dbuser = 'camilo';
$dbpass = 'Noviembre2018';
$dbhost = 'localhost';

$conect = new mysqli($dbhost, $dbuser, $dbpass,$dbname);

$userID = $_REQUEST['IDuser'];

$consulta = mysqli_query($conect, "SELECT * FROM CallOfDutyColombia WHERE UserID ='$userID' ");

while($Decisiones= mysqli_fetch_array($consulta))
{
    $Dec1 = $Decisiones['Dec1'];
    $Dec2 = $Decisiones['Dec2'];
    $Dec3 = $Decisiones['Dec3'];
    $Dec4 = $Decisiones['Dec4'];
    $Dec5 = $Decisiones['Dec5'];
    $Dec6 = $Decisiones['Dec6'];
}

echo $Dec1;
echo "-";
echo $Dec2;
echo "-";
echo $Dec3;
echo "-";
echo $Dec4;
echo "-";
echo $Dec5;
echo "-";
echo $Dec6;

?>