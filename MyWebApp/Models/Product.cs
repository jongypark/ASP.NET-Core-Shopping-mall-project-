using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "제품 카테고리가 입력되지 않았습니다.")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "제품명이 입력되지 않았습니다.")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "가능한 단가 범위를 벗어났습니다.")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
    }
}