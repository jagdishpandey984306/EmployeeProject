// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    localStorage.removeItem("records");
    $("#DOB").datepicker({ dateFormat: "yy/mm/dd" });
});

$('#btnAdd').on('click', function () {
    let Q_Id, Qualification, Marks;
    Q_Id = document.getElementById('Q_Id').value;
    Qualification = $("#Q_Id option:selected").text();
    Marks = parseFloat(document.getElementById('Marks').value = "" ? 0 : document.getElementById('Marks').value);
    if (isNaN(Marks) || Marks <= 0) {
        toastr.error("Marks is required.", "Alert");
    }
    else {
        let records = new Array();
        records = JSON.parse(localStorage.getItem("records")) ? JSON.parse(localStorage.getItem("records")) : []
        if (records.some((v) => { return v.Q_Id == Q_Id })) {
            toastr.error("This record is already exists.", "Alert");
        }
        else {
            records.push({
                "Q_Id": Q_Id,
                "Qualification": Qualification,
                "Marks": Marks
            })
            localStorage.setItem('records', JSON.stringify(records));
        }
        toastr.success("Added Sucessfully.", "success");
        document.getElementById('QualificationList').value = localStorage.getItem("records");
        LoadData();
    }
});

$('#btnEdit').on('click', function () {

});

function LoadData() {
    let tbody;
    let i = 1;
    let data = JSON.parse(localStorage.getItem("records")) ? JSON.parse(localStorage.getItem("records")) : []
    data.forEach((item) => {
        tbody += '<tr ondblclick="getData(' + item.Q_Id + ', ' + item.Marks +')">';
        tbody += '<td>' + i + '</td>';
        tbody += '<td>' + item.Qualification + '</td>';
        tbody += '<td>' + item.Marks + '</td>';
        tbody += "</tr>";
        i++;
    });
    $('#bindData').html(tbody);
}

function Delete(Q_Id) {
    var data = JSON.parse(localStorage.getItem("records")) ? JSON.parse(localStorage.getItem("records")) : []
    data = data.filter(e => e.Q_Id !== Q_Id);
    localStorage.setItem('records', JSON.stringify(data));
    window.location.reload(false);
    LoadData();
}

function OnClickList(EmployeeId) {
    let tbody;
    let i = 1;
    $.ajax({
        type: 'post',
        url: "/Employee/EmployeeListById",
        data: { EmployeeId: EmployeeId },
        dataType: 'json',
        success: function (res) {
            $('#Employee_Id').val(res.employee.employee_Id);  
            $('#Emp_Name').val(res.employee.emp_Name);
            if ($('.Male').val() == res.employee.gender) {
                $('.Male').prop("checked", true);
            }
            else if ($('.Female').val() == res.employee.gender) {
                $('.Female').prop("checked", true);
            }
            else {
                $('.ThirdGender').prop("checked", true);
            }
            $('#DOB').val(ConvertJsonDateString(res.employee.dob));
            $('#Salary').val(res.employee.salary);

            localStorage.setItem('records', JSON.stringify(res.employeeQualification));


            let data = JSON.parse(localStorage.getItem("records")) ? JSON.parse(localStorage.getItem("records")) : []
            data.forEach((item) => {
                tbody += '<tr ondblclick="getData(' + item.q_Id + ', ' + item.marks +')">';
                tbody += '<td>' + i + '</td>';
                tbody += '<td>' + item.q_Name + '</td>';
                tbody += '<td>' + item.marks + '</td>';
                tbody += "</tr>";
                i++;
            });

            $('#bindData').html(tbody);
            $('#btnSubmit').addClass('hide');
            $('#btnUpdate').removeClass('hide');
            document.getElementById('QualificationList').value = localStorage.getItem("records");
        }
    });
}

function ConvertJsonDateString(jsonDate) {
    var shortDate = null;
    if (jsonDate) {
        let datee = jsonDate.split("-");
        let datee1 = datee[2].split("T");
        let year = datee[0];
        let month = datee[1];
        let day = datee1[0];
        var shortDate = year + "/" + month + "/" + day;
    }
    return shortDate;
};


function reset() {
    $('#Employee_Id').val('0');   
    $('#Emp_Name').val('');
    if ($('.Male').is(':checked')) {
        $('.Male').prop("checked", false);
    }
    else if ($('.Female').is(':checked')) {
        $('.Female').prop("checked", false);
    }
    else {
        $('.ThirdGender').prop("checked", false);
    }
    $('#DOB').val('');
    $('#Salary').val('');
    localStorage.removeItem("records");
    LoadData();
    $('#btnSubmit').removeClass('hide');
    $('#btnUpdate').addClass('hide');
    $('#btnAdd').removeClass('hide');
    $('#btnEdit').addClass('hide');
}

function getData(q_id, q_name) {
    $('#Q_Id').val(q_id).change();
    $('#Marks').val(q_name);
    $('#btnAdd').addClass('hide');
    $('#btnEdit').removeClass('hide');
}



