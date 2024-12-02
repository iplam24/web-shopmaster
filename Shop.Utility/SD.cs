using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Utility
{
    public static class SD
    {
        public const string Role_Customer = "khách hàng";
        public const string Role_Company = "công ty";
        public const string Role_Admin = "Quản trị viên";
        public const string Role_Employee = "nhân viên";


        public const string StatusPending = "Đang chờ xử lý";
        public const string StatusApproved = "Đang xử lý - gọi xác nhận";
        public const string StatusInProcess = "Đã xác nhận - đóng gói sản phẩm";
        public const string StatusShipped = "Đã giao hàng";
        public const string StatusCancelled = "Đã hủy";
        public const string StatusRefunded = "Đã hoàn tiền";

        public const string PaymentStatusPending = "Đang chờ xử lý";
        public const string PaymentStatusApproved = "Đã thanh toán";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
        public const string PaymentStatusRejected = "loại bỏ";


        public const string SessionCart = "SessionShoppingCart";

    }
}