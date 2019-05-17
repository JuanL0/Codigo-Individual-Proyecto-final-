<?php

$dbname = 'UnityDB';
$dbuser = 'camilo';
$dbpass = 'Noviembre2018';
$dbhost = 'localhost';

$conect = new mysqli($dbhost, $dbuser, $dbpass,$dbname);

//Decision 1
//A
$DecA_1 = mysqli_query($conect, "SELECT COUNT(*) AS mycountA_1 FROM CallOfDutyColombia WHERE Dec1 = 1 " );
$resA_1 = mysqli_fetch_object($DecA_1);
$countA_1 = $resA_1->mycountA_1;
echo $countA_1;
echo "-";
//B
$DecB_1 = mysqli_query($conect, "SELECT COUNT(*) AS mycountB_1 FROM CallOfDutyColombia WHERE Dec1 = 2 " );
$resB_1 = mysqli_fetch_object($DecB_1);
$countB_1 = $resB_1->mycountB_1;
echo $countB_1;
echo "-";

//Decision 2
//A
$DecA_2 = mysqli_query($conect, "SELECT COUNT(*) AS mycountA_2 FROM CallOfDutyColombia WHERE Dec2 = 1 " );
$resA_2 = mysqli_fetch_object($DecA_2);
$countA_2 = $resA_2->mycountA_2;
echo $countA_2;
echo "-";
//B
$DecB_2 = mysqli_query($conect, "SELECT COUNT(*) AS mycountB_2 FROM CallOfDutyColombia WHERE Dec2 = 2 " );
$resB_2 = mysqli_fetch_object($DecB_2);
$countB_2 = $resB_2->mycountB_2;
echo $countB_2;
echo "-";

//Decision 3
//A
$DecA_3 = mysqli_query($conect, "SELECT COUNT(*) AS mycountA_3 FROM CallOfDutyColombia WHERE Dec3 = 1 " );
$resA_3 = mysqli_fetch_object($DecA_3);
$countA_3 = $resA_3->mycountA_3;
echo $countA_3;
echo "-";
//B
$DecB_3 = mysqli_query($conect, "SELECT COUNT(*) AS mycountB_3 FROM CallOfDutyColombia WHERE Dec3 = 2 " );
$resB_3 = mysqli_fetch_object($DecB_3);
$countB_3 = $resB_3->mycountB_3;
echo $countB_3;
echo "-";

//Decision 4
//A
$DecA_4 = mysqli_query($conect, "SELECT COUNT(*) AS mycountA_4 FROM CallOfDutyColombia WHERE Dec4 = 1 " );
$resA_4 = mysqli_fetch_object($DecA_4);
$countA_4 = $resA_4->mycountA_4;
echo $countA_4;
echo "-";
//B
$DecB_4 = mysqli_query($conect, "SELECT COUNT(*) AS mycountB_4 FROM CallOfDutyColombia WHERE Dec4 = 2 " );
$resB_4 = mysqli_fetch_object($DecB_4);
$countB_4 = $resB_4->mycountB_4;
echo $countB_4;
echo "-";

//Decision 5
//A
$DecA_5 = mysqli_query($conect, "SELECT COUNT(*) AS mycountA_5 FROM CallOfDutyColombia WHERE Dec5 = 1 " );
$resA_5 = mysqli_fetch_object($DecA_5);
$countA_5 = $resA_5->mycountA_5;
echo $countA_5;
echo "-";
//B
$DecB_5 = mysqli_query($conect, "SELECT COUNT(*) AS mycountB_5 FROM CallOfDutyColombia WHERE Dec5 = 2 " );
$resB_5 = mysqli_fetch_object($DecB_5);
$countB_5 = $resB_5->mycountB_5;
echo $countB_5;
echo "-";

//Decision 6
//A
$DecA_6 = mysqli_query($conect, "SELECT COUNT(*) AS mycountA_6 FROM CallOfDutyColombia WHERE Dec6 = 1 " );
$resA_6 = mysqli_fetch_object($DecA_6);
$countA_6 = $resA_6->mycountA_6;
echo $countA_6;
echo "-";
//B
$DecB_6 = mysqli_query($conect, "SELECT COUNT(*) AS mycountB_6 FROM CallOfDutyColombia WHERE Dec6 = 2 " );
$resB_6 = mysqli_fetch_object($DecB_6);
$countB_6 = $resB_6->mycountB_6;
echo $countB_6;

?>