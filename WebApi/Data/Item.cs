using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data;

public class Item
{
    [Key]
    public int ItemId { get; set; }

    [Required(ErrorMessage = "ItemName is required")]
    public string ItemName { get; set; } = string.Empty;

    [Required(ErrorMessage = "ItemDescription is required")]
    public string ItemDescription { get; set; } = string.Empty;

    [Required(ErrorMessage = "ItemStatus is required")]
    public bool ItemStatus { get; set; }
}