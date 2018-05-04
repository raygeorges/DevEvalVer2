$(document).ready(function () {
    //Bind keyup event handler to userinput input field when dom is loaded
    $("#userinput").on("keyup", function (e) {
        //if the enter key was pressed, invoke check input function
        if (e.which === 13) { //13 is the normalized jQuery keycode for enter
            checkInput();
        }
    });

    //Define our modals as modals
    $("#inputErrorModal").modal({
        show: false //Do not show on initialization
    });

    $("#calculationErrorModal").modal({
        show: false
    })
});

//define a counter for our calculations to display to the user
var calcCounter = 0;

//Invoked when user attempts to submit input.
function checkInput() {

    //disable form elements
    lockControls();

    //retrieve user provided input
    var input = $("#userinput").val();

    //define our validation pattern
    var validationPattern = "^-?.?[0-9]\\d*(\\.\\d+)?$";

    //split items, check against regex pattern,
    var inputArray = input.split(',');
    var failedValidation = false;
    if (inputArray.length > 0) {
        for (var i = 0; i < inputArray.length; i++) {
            if (!inputArray[i].match(validationPattern)) {
                //If a portion of input fails validation, set flag to true & break out of loop.
                failedValidation = true;
                break;
            }
        }
    }
    else {
        //Reject blank entry
        failedValidation = true;
    }
    if (!failedValidation) {
        //Input checks out, post to controller
        sendToBackend(input);
    }
    else {
        //Display an alert informing the user that they have provided invalid input. Wipe input field value. Re-enable controls.
        $("#inputErrorModal").modal('show');
        $("#userinput").val("");
        unlockControls();
    }

}

function sendToBackend(userInput) {
    $.post("api/Calculate", { "input":userInput })
        .done(function (data, status, jqxhr) {
            calcCounter++;
            $("#resultContainer").append(generateCalculationRow(data))
            unlockControls();
        })
        .fail(function (data, status, jqxhr) {
            $("#calculationErrorModal").modal('show');
            unlockControls();
        })
}

//Dynamically generates html for every calculation
function generateCalculationRow(data) {
    return '<div class="resultBlock"><div class="col-md-12"><p>Calculation #: ' + calcCounter + ' Last calculation time: ' + new Date().toLocaleString() + '</p></div><div class="col-md-12"><label id="mean_label">&nbsp; Mean: ' + data.mean + '</label><label id="median_label">&nbsp; Median: ' + data.median + '</label><label id="mode_label">&nbsp; Mode: ' + data.mode + '</label></div></div></div>'
}

function lockControls() {
    $("#userinput").attr("disabled", "disabled");
    $("#calculatebutton").attr("disabled", "disabled");
}

function unlockControls() {
    $("#userinput").removeAttr("disabled");
    $("#calculatebutton").removeAttr("disabled");
}