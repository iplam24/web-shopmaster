// wwwroot/js/user.js

$(document).ready(function () {
    // Thực hiện cuộc gọi API để lấy dữ liệu người dùng
    $.ajax({
        type: "GET",
        url: "/Admin/User/GetAll",
        success: function (data) {
            // Xử lý dữ liệu trả về và nối vào cơ thể bảng
            var tableBody = $("#userTableBody");
            tableBody.empty(); // Xóa dữ liệu hiện tại

            $.each(data.dat, function (index, user) {
                var row = "<tr>" +
                    "<td>" + user.id + "</td>" +
                    "<td>" + user.userName + "</td>" +
                    "<td>" + user.email + "</td>" +
                    "<td>" + (user.company ? user.company.name : "N/A") + "</td>" +
                    "</tr>";

                tableBody.append(row);
            });
        },
        error: function (error) {
            console.log("Lỗi khi truy xuất dữ liệu người dùng: " + error);
        }
    });
});
