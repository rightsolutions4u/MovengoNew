<?php
header('Content-type: application/json');
require_once('php-mailer/PHPMailerAutoload.php'); // Include PHPMailer

$mail = new PHPMailer();
$emailTO = array();

// Enter Your Sitename 
$sitename = 'Your Site Name';

// Enter your email addresses: @required
$emailTO[] = array( 'email' => 'your email address', 'name' => 'Your Name' ); 

// Enter Email Subject
$subject = "New Subscriber Notification" . ' - ' . $sitename; 

// Success Messages
$msg_success = "You have been <strong>successfully</strong> subscribed.";

if( $_SERVER['REQUEST_METHOD'] == 'POST') {
	if (isset($_POST["EMAIL"]) && $_POST["EMAIL"] != '') {
		// Form Fields
		$sf_email = $_POST["EMAIL"];

		$honeypot 	= isset($_POST["form-anti-honeypot"]) ? $_POST["form-anti-honeypot"] : '';
		$bodymsg = '';
		
		if ($honeypot == '' && !(empty($emailTO))) {
			$mail->IsHTML(true);
			$mail->CharSet = 'UTF-8';

			$mail->From = $sf_email;
			$mail->FromName = $sitename;
			$mail->Subject = $subject;
			
			foreach( $emailTO as $to ) {
				$mail->AddAddress( $to['email'] , $to['name'] );
			}
			
			// Include Form Fields into Body Message
			$bodymsg .= isset($sf_email) ? "Subscriber Email: $sf_email<br><br>" : '';
			$bodymsg .= $_SERVER['HTTP_REFERER'] ? '<br>---<br><br>This email was sent from: ' . $_SERVER['HTTP_REFERER'] : '';
			
			$mail->MsgHTML( $bodymsg );
			$is_emailed = $mail->Send();

			if( $is_emailed === true ) {
				$response = array ('result' => "success", 'message' => $msg_success);
			} else {
				$response = array ('result' => "error", 'message' => $mail->ErrorInfo);
			}
			echo json_encode($response);
			
		} else {
			echo json_encode(array ('result' => "error", 'message' => "Bot <strong>Detected</strong>.! Clean yourself Botster.!"));
		}
	} else {
		echo json_encode(array ('result' => "error", 'message' => "Please <strong>Fill up</strong> all required fields and try again."));
	}
}