<?php
session_start();

// checking if user is logged 
if (!isset($_SESSION['user_id'])) {
    header("Location: login.php");
    exit();
}
?>


<!DOCTYPE html>
<html lang="pl">
<head>
    <link rel="stylesheet" type="text/css" href="styles.css">
    <link rel="stylesheet" href="kot.png" type="image/x-icon">
</head>
<body>


<?php
    function generateText($text, $repeat) {
        for ($i = 0; $i < $repeat; $i++) {
            echo $text;
        }
    }
?>

<!-- grid for text 2x2 -->
<div class="grid-section-1">
    <div class="item">
        <?php generateText('jakub czabok ', 30); ?>
    </div>
    <div class="item">
        inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst
    </div>
</div>

        <!-- grid for text 3x1 -->
        <div class="grid-section-2">
            <div class="item">jakub czabok jakub czabok jakub czabok
                jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok
                jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok</div>
            <div class="item">inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekstinny tekst inny tekst inny tekstinny tekst inny tekst inny tekstinny tekst inny tekst inny tekstinny tekst inny tekst inny tekstv</div>
            <div class="item">jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok  jakub czabok
                jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok
                jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok</div>
        </div>



        <div class="grid-section-3">
            <div class="item">jakub czabok jakub czabok jakub czabok
                jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok
                jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok</div>
            <div class="item">inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekstinny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekstinny tekst inny tekst inny tekst</div>
            <div class="item">jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok  jakub czabok
                jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok
                jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok</div>
                <div class="item">inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekstinny tekst inny tekst inny tekstinny tekst inny tekst inny tekstinny tekst inny tekst inny tekstinny tekst inny tekst inny tekstinny tekst inny tekst inny tekst</div>
        
            </div>

            <div class="grid-section-4">
                <div class="item">jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok
                    jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok</div>
                <div class="item">inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekstinny tekst inny tekst inny tekstinny tekst inny tekst inny tekst</div>
                <div class="item">jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok  jakub czabok
                    jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok
                     jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok</div>
                    <div class="item">inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekstinny tekst inny tekst inny tekstinny tekst inny tekst inny tekst</div>
                        <div class="item">jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok  jakub czabok
                            jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok
                            jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok</div>
                </div>

            
                <div class="grid-section-5">
                    <div class="item">jakub czabok jakub czabok jakub czabok
                        jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok
                        jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok</div>
                    <div class="item">inny tekst inny tekst inny tekst inny tekst inny tekst inny tekstinny tekst inny tekst inny tekstinny tekst inny tekst inny tekst</div>
                    <div class="item">jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok  jakub czabok
                        jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok
                        jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok</div>
                        <div class="item">inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst v inny tekst inny tekst inny tekstinny tekst inny tekst inny tekst</div>
                            <div class="item">jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok  jakub czabok
                                jakub czabok jakub czabok jakub akub czabok jakub czaczabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok jakub czabok</div>
                                <div class="item">inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekst inny tekstvinny tekst inny tekst inny tekstinny tekst inny tekst inny tekst</div> 
                            </div>

                            <br>
<a href="logout.php">wyloguj</a> <!-- link for logging out -->
                         
</body>
</html>
