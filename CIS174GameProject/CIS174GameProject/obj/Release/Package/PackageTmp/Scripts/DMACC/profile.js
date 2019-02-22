function searchPeople()
{
    var search = $("#userID").val();

    $.ajax({
        url: "Search",
        data: { searchGuid: search.toString() }
    }).done(function (data) {
        $("#personId").val(data.PersonId);
        $("#firstName").val(data.FirstName);
        $("#lastName").val(data.LastName);
        $("#gender").val(data.Gender);
        $("#email").val(data.Email);
        $("#dateCreated").val(data.DateCreated);
        $("#phoneNumber").val(data.PhoneNumber);
        if (data.PersonId == "00000000-0000-0000-0000-000000000000")
        {
            $("#CreateProfile").removeClass("hidden");
        }
        else
        {
            $("#Form").removeClass("hidden");
            ToJavaScriptDate();
        }
    });
}

function searchPeopleCreate()
{
    var search = $("#userID").val();

    $.ajax({
        url: "Search",
        data: { searchGuid: search.toString() }
    }).done(function (data) {
        $("#personId").val(data.PersonId);
        if (data.PersonId == "00000000-0000-0000-0000-000000000000")
        {
            $("#CreateForm").removeClass("hidden");
        }
        else {
            $("#Success").removeClass("hidden");
        }
    });
}

function createPerson()
{
    var firstName = $("#firstName").val();
    var lastName = $("#lastName").val();
    var gender = $("#gender").val();
    var email = $("#email").val();
    var phoneNumber = $("#phoneNumber").val();

    var phoneNumber = document.forms["personForm"]["phoneNumber"].value;
    if (phoneNumber != "")
    {
        var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;

        if (phoneno.test(phoneNumber) == false)
        {
            alert("Please enter a valid phone number.");
            return ("");
        }
    }

    $.ajax({
        url: "CreatePerson",
        dataType: "json",
        data: {
            FirstName: firstName,
            LastName: lastName,
            Gender: gender,
            Email: email,
            PhoneNumber: phoneNumber
        }
    }).done(function (data) {
        if (data)
        {
            alert("Success!");
        }
        else
        {
            alert("Failure to Create.");
        }
    });
}

function updatePerson()
{
    var personId = $("#personId").val();
    var firstName = $("#firstName").val();
    var lastName = $("#lastName").val();
    var gender = $("#gender").val();
    var email = $("#email").val();
    var phoneNumber = $("#phoneNumber").val();

    if (phoneNumber != "")
    {
        var phoneNumber = document.forms["personForm"]["phoneNumber"].value;
        var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;

        if (phoneno.test(phoneNumber) == false) {
            alert("Please enter a valid phone number.");
            return ("");
        }
    }

    $.ajax({
        url: "UpdatePerson",
        dataType: "json",
        data: {
            PersonId: personId,
            FirstName: firstName,
            LastName: lastName,
            Gender: gender,
            Email: email,
            PhoneNumber: phoneNumber
        }
    }).done(function (data)
    {
        if (data)
        {
            alert("Success!");
        }
        else
        {
            alert("Failure to Upload.");
        }
    });
}

// Function found on - https://stackoverflow.com/questions/27314663/asp-net-parse-datetime-result-from-ajax-call-to-javascript-date
function ToJavaScriptDate()
{
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec($("#dateCreated").val());
    var dt = new Date(parseFloat(results[1]));
    return $("#dateCreated").val((dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear());
}