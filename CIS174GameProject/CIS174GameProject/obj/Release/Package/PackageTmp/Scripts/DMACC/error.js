function createErrorLog(message, trace, exception)
{
    $.ajax({
        url: "CreateErrorLog",
        dataType: "json",
        data: {
            ErrorMessage: message,
            StackTrace: trace,
            InnerExceptions: exception
        }
    }).done(function (data) {
        if (data) {
            alert("Error Log Successful.");
        }
        else {
            alert("Error Log Failure.");
        }
    });
}

function generateError()
{
    $.ajax({
        url: "CauseError"
    });
}
