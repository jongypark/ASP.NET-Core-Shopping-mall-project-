using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartItems> Items { get; set; } = new List<CartItems>();

        [Required(ErrorMessage = "이릅이 입력되지 않았습니다.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "전화번호가 입력되지 않았습니다.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "배송주소가 입력되지 않았습니다.")]
        public string? Address { get; set; }
    }
}