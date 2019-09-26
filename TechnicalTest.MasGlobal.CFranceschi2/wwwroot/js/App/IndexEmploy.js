$(document).ready(function () {
    searchEmployees();
    $("#btnSearch").click(function () {
        var Id = $("#txtIdEmployee").val();
        $("#tblEmployee tr").detach();
        //SearchById(Id);
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
                tablaBody += "<td>" + item.Id + "</td>";
                tablaBody += "<td> " + item.Name + "</td>";
                tablaBody += "<td>" + item.ContractTypeName + "</td>";
                tablaBody += "<td>" + item.RoleName + "</td>";
                tablaBody += "<td>" + item.RoleDescription + "</td>";
                //tablaBody += "<td>" + item.HourlySalary + "</td>";
                //tablaBody += "<td>" + item.MonthlySalary + "</td>";
                tablaBody += "<td>" + item.AnnualSalary + "</td>";
                tablaBody += "</tr> ";

            });


            $('#tblClientes tbody').append(tablaBody);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ' ' + errorThrown);
        }

    });

}

//function SearchById(Id) {

//    $.ajax({
//        url: '/Employee/SearchEmployees/?Id=' + Id,
//        type: 'POST',
//        datatype: 'JSON',
//        data: Id,
//        success: function (respuesta) {


//            var tablaBody = "<table id='tblClientes' class='table table - bordered table - hover'><thead>";
//            tablaBody += "<tr><th>Id Employee</th><th>Employee Name</th><th>Contract Type</th><th>Role Name</th><th>Rol Description</th><th>Annual Salary</th></tr >";
//            tablaBody += " </thead><tbody>";

//            $.each(respuesta, function (indice, item) {

//                tablaBody += "<tr>";
//                tablaBody += "<td>" + item.Id + "</td>";
//                tablaBody += "<td> " + item.Name + "</td>";
//                tablaBody += "<td>" + item.ContractTypeName + "</td>";
//                tablaBody += "<td>" + item.RoleName + "</td>";
//                tablaBody += "<td>" + item.RoleDescription + "</td>";
//                tablaBody += "<td>" + item.AnnualSalary + "</td>";
//                tablaBody += "</tr> ";

//            });
//            tablaBody += "<tbody></table>"
//            $("#tblClientes").append(tablaBody);
//        },
//        error: function (jqXHR, textStatus, errorThrown) {
//            console.log(textStatus + ' ' + errorThrown);
//        }

//    });

//}

