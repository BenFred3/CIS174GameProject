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
        $("#genderSelect").val(data.Gender);
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
    if (!$("#successMessage").is(":hidden"))
    {
        $("#successMessage").addClass("hidden");
    }

    if (!$("#errorMessage").is(":hidden"))
    {
        $("#errorMessage").addClass("hidden");
    }

    var firstName = $("#firstName").val();
    var lastName = $("#lastName").val();
    var gender = $("#genderSelect").val();
    var email = $("#email").val();
    var phoneNumber = $("#phoneNumber").val();

    if (!firstName)
    {
        $("#errorMessage").removeClass("hidden").text('A first name is required.');
        return ("");
    }

    if (!lastName)
    {
        $("#errorMessage").removeClass("hidden").text('A last name is required.');
        return ("");
    }

    if (!email)
    {
        $("#errorMessage").removeClass("hidden").text('A email is required.');
        return ("");
    }

    if (firstName.length > 50)
    {
        $("#errorMessage").removeClass("hidden").text('Please enter in a first name that is less than 50 characters.');
        return ("");
    }

    if (lastName.length > 50)
    {
        $("#errorMessage").removeClass("hidden").text('Please enter in a last name that is less than 50 characters.');
        return ("");
    }

    if (email.length > 100)
    {
        $("#errorMessage").removeClass("hidden").text('Please enter in a email that is less than 100 characters.');
        return ("");
    }

    if (phoneNumber != "")
    {
        var phoneNumber = document.forms["personForm"]["phoneNumber"].value;
        var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;

        if (phoneno.test(phoneNumber) == false)
        {
            $("#errorMessage").removeClass("hidden").text('Please enter a valid phone number.');
            return ("");
        }
    }

    var emailcheck = /[^@\s]+@[^@\s]+\.[^@\s]+/;

    if (emailcheck.test(email) == false)
    {
        $("#errorMessage").removeClass("hidden").text('Please enter a valid email address.');
        return ("");
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
            $("#successMessage").removeClass("hidden").text('Successfully updated the database.');
            $("#Success").removeClass("hidden");
            $("#CreateForm").addClass("hidden");
        }
        else
        {
            $("#errorMessage").removeClass("hidden").text('There was an error while updating the database.');
        }
    });
}

function updatePerson()
{
    if (! $("#successMessage").is(":hidden"))
    {
        $("#successMessage").addClass("hidden");
    }

    if (! $("#errorMessage").is(":hidden"))
    {
        $("#errorMessage").addClass("hidden");
    }

    var personId = $("#personId").val();
    var firstName = $("#firstName").val();
    var lastName = $("#lastName").val();
    var gender = $("#genderSelect").val();
    var email = $("#email").val();
    var phoneNumber = $("#phoneNumber").val();

    if (!firstName)
    {
        $("#errorMessage").removeClass("hidden").text('A first name is required.');
        return ("");
    }

    if (!lastName)
    {
        $("#errorMessage").removeClass("hidden").text('A last name is required.');
        return ("");
    }

    if (!email)
    {
        $("#errorMessage").removeClass("hidden").text('A email is required.');
        return ("");
    }

    if (firstName.length > 50)
    {
        $("#errorMessage").removeClass("hidden").text('Please enter in a first name that is less than 50 characters.');
        return ("");
    }

    if (lastName.length > 50)
    {
        $("#errorMessage").removeClass("hidden").text('Please enter in a last name that is less than 50 characters.');
        return ("");
    }

    if (email.length > 100)
    {
        $("#errorMessage").removeClass("hidden").text('Please enter in a email that is less than 100 characters.');
        return ("");
    }

    if (phoneNumber != "")
    {
        var phoneNumber = document.forms["personForm"]["phoneNumber"].value;
        var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;

        if (phoneno.test(phoneNumber) == false)
        {
            $("#errorMessage").removeClass("hidden").text('Please enter a valid phone number.');
            return ("");
        }
    }

    var emailcheck = /[^@\s]+@[^@\s]+\.[^@\s]+/;

    if (emailcheck.test(email) == false)
    {
        $("#errorMessage").removeClass("hidden").text('Please enter a valid email address.');
        return ("");
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
        $("Form").submit(function (f)
        {
            f.preventDefault();
        });

        if (data)
        {
            $("#successMessage").removeClass("hidden").text('Successfully updated the database.');
        }
        else
        {
            $("#errorMessage").removeClass("hidden").text('There was an error while updating the database.');
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