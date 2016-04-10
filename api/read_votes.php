<?php

header('Content-Type: application/json');

$votes = array();

$files = glob("*.txt");

foreach ($files as $file_name) {

		$vote_count = file_get_contents($file_name);

		$basename = basename($file_name, ".txt");

		$votes[$basename] = $vote_count;
}

//print_r($votes);
$json = json_encode($votes);
echo $json;

?>