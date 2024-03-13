using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ItemAPI;

[ApiController]
[Route("[controller]")]

public class ItemController : ControllerBase
{
    private readonly ItemService _itemService;

    public ItemController(ItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]// Retrieving alist of all items
    public ActionResult<IEnumerable<Item>> GetItems()
    {
        if (_itemService.GetItems().ToList().Count == 0)
        {
            return NotFound(new { Error = "No items found" });
        }
        return _itemService.GetItems().ToList();
    }

    [HttpGet("{Id}")] // Retrieving details of a specific item
    public ActionResult<Item> GetItem(int Id)
    {
        var item = _itemService.GetItem(Id);
        if (item == null)
        {
            return NotFound(new { Error = " No Item with that ID found" });
        }
        return Ok(item);
    }
    
    [HttpPost]//for creating a new item
    public ActionResult<Item> CreateItem([FromBody] Item item)
    {
        
        var newItem = _itemService.CreateItem(item);
        return CreatedAtAction(nameof(CreateItem), new { id = newItem.Id }, newItem);
    }

    [HttpPut("{id}")]

    public ActionResult<Item> UpdateItem(int id, [FromBody] Item item)
    {
        try
        {
            var updatedItem = _itemService.UpdateItem(id, item);
            return Ok(updatedItem);
        }
        catch (Exception e)
        {
            return BadRequest(new { Error = "No input found" });
        }
    }

    [HttpPatch("updateprice/{id}")]//for updating the price of an item
    public ActionResult<Item> UpdatePrice(int id, [FromBody] decimal price)
    {
        try
        {
            var updatedItem = _itemService.UpdatePrice(id, price);
            return Ok(updatedItem);
        }
        catch (Exception e)
        {
            return BadRequest(new { Error = e.Message });
        }
    }

    [HttpDelete("{id}")]//for deleting an item
    public ActionResult<Item> DeleteItem(int id)
    {
        try
        {
            _itemService.DeleteItem(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new { Error = e.Message });
        }
    }
}



