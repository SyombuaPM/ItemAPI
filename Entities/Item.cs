using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemAPI;

[Table("Item")]
public class Item
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    // create a property price that doesnt allow negative values
    private decimal _price;
    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            _price = value;
        }
    }

    public Item(int id, string name, string description, decimal price)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }
        
        // if (price)
        // {
        //     throw new ArgumentException("Price cannot be negative");
        // }
        Id = id;
        Name = name;
        Description = description;
        Price = price;
    }

    public Item()
    {
   }  
   // end of default constructor



}


