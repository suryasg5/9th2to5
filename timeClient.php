<body>
<?php
//cerner_2tothe5th_2022
//cerner_2^5_2022
//PHP time client
if ($_SERVER["REQUEST_METHOD"] == "POST") {
  $timeId = $_POST['timeId'];
  if (empty($timeId)) {
    echo "Select a time zone"; 
  }
  else {  
	$socket = socket_create(AF_INET, SOCK_STREAM, 0) or die("Could not create socket<br>");
    $result = socket_connect($socket, "127.0.0.1", 49152) or die("Could not connect to server<br>"); 	
	socket_write($socket, $timeId . "\n", strlen($timeId)+1) or die("Could not send data to server\n");
	$result = socket_read ($socket, 1024) or die("Could not read server response\n");
    echo "<h3>$result</h3>";
	socket_close($socket);
  } 
}
?>
<form name="tc" method="post" action="timeClient.php">
<select name="timeId">
<?php
$tzlist = DateTimeZone::listIdentifiers(DateTimeZone::ALL);
foreach($tzlist as $tz) {
  echo "<option value=\"$tz\">$tz</option>\n";
}
?>
</select>
<input type="submit" value="submit"/>
</form>
</body>
