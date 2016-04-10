<?php

 header('Access-Control-Allow-Origin: *');
header('content-type: application/json; charset=utf-8');

// Parse ID parameter
$id = isset($_REQUEST ['id']) ? (int) $_REQUEST ['id'] : null;

// Error message if none or not an integer
if (!$id) { // === 0 || === null
  header('HTTP/1.1 404 Not Found');
  exit('404, page not found');
}

// Just store each vote vount in a text file for now so don't need to setup a DBMS
// Names are 1.txt, 2.txt, etc..
$file_name = $id . '.txt';

// Read the previous count
$vote_count = 0;
if ( file_exists($file_name) ) {
	$previous_vote_count_string = file_get_contents($file_name);
	if ($previous_vote_count_string) {
		$vote_count = (int) $previous_vote_count_string;
	}
}

// Write the vote count to the browser
echo $vote_count;

?>