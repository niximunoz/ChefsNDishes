#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage = "Por favor proporciona este dato!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Por favor proporciona este dato!")]
    [Range(1, 5, ErrorMessage = "El valor para {0} debe estar entre {1} y {2}.")]
    public int Tastiness { get; set; }
    [Required(ErrorMessage = "Por favor proporciona este dato!")]
    [Range(1, int.MaxValue, ErrorMessage = "Las calorías deben ser superiores a 0.")]
    public int Calories { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int ChefId { get; set; }

    public Chef? Creator { get; set; }
}