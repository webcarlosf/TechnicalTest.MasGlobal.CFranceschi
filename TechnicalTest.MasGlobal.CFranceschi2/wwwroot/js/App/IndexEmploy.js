$(document).ready(function () {
    searchEmployees();
    $("#btnSearch").click(function () {
        var Id = $("#txtIdEmployee").val();
        $("#tblEmployee tr").detach();
        SearchById(Id);
    });
});

function searchEmployees() {
    $.ajax({
        url: '/Home/SearchEmployees',
        type: 'POST',
        datatype: 'JSON',
        data: { data: '0' },
        success: function (respuesta) {
            var tablaBody = "";
            $.each(respuesta, function (indice, item) {
                tablaBody += "<tr>";
                debugger;
                tablaBody += "<td>" + item.id + "</td>";
                tablaBody += "<td> " + item.name + "</td>";
                tablaBody += "<td>" + item.contractTypeName + "</td>";
                tablaBody += "<td>" + item.roleName + "</td>";
                tablaBody += "<td>" + item.roleDescription + "</td>";
                //tablaBody += "<td>" + item.hourlySalary + "</td>";
                //tablaBody += "<td>" + item.monthlySalary + "</td>";
                tablaBody += "<td>" + item.annualSalary + "</td>";
                tablaBody += "</tr> ";
            });
            $('#tblEmployee tbody').append(tablaBody);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }
    });
}

function SearchById(Id) {
    $.ajax({
        url: '/Home/SearchEmployees?Id=' + Id,
        type: 'POST',
        datatype: 'JSON',
        data: Id,
        success: function (respuesta) {
            var tablaBody = "<table id='tblClientes' class='table table - bordered table - hover'><thead>";
            tablaBody += "<tr><th>Id Employee</th><th>Employee Name</th><th>Contract Type</th><th>Role Name</th><th>Rol Description</th><th>Annual Salary</th></tr >";
            tablaBody += " </thead><tbody>";
            $.each(respuesta, function (indice, item) {
                tablaBody += "<tr>";
                tablaBody += "<td>" + item.id + "</td>";
                tablaBody += "<td> " + item.name + "</td>";
                tablaBody += "<td>" + item.contractTypeName + "</td>";
                tablaBody += "<td>" + item.roleName + "</td>";
                tablaBody += "<td>" + item.roleDescription + "</td>";
                //tablaBody += "<td>" + item.hourlySalary + "</td>";
                //tablaBody += "<td>" + item.monthlySalary + "</td>";
                tablaBody += "<td>" + item.annualSalary + "</td>";
                tablaBody += "</tr> ";
            });
            tablaBody += "<tbody></table>";
            $("#tblEmployee").append(tablaBody);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }
    });
}

