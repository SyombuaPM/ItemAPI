using Microsoft.EntityFrameworkCore;

namespace ItemAPI;

public class ItemService
{ 
    private readonly ItemDbContext _context;

    public ItemService(ItemDbContext context)
    {
        _context = context;
    }


    // create method without async
    public IEnumerable<Item> GetItems()
    {
        return _context.Items.ToList();
    }


    public Item GetItem(int id)
    {
        return _context.Items.FirstOrDefault(i => i.Id == id);
    }


    public Item CreateItem(Item item)
    {
        _context.Items.Add(item);
        _context.SaveChanges();
        return item;
    }

    public Item UpdateItem(int id, Item item)
    {
        _context.Entry(item).State = EntityState.Modified;
        _context.SaveChanges();
        return item;
    }


    public  Item UpdatePrice(int id, decimal price)
    {
        var item = _context.Items.Find(id);
        if (item != null)
        {
            item.Price = price;
            _context.SaveChanges();
        }
        return item;
    }

    public void DeleteItem(int id)
    {
        var item = _context.Items.Find(id);
        if (item != null)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }
    }


    // public async Task<List<Item>> GetItemsAsync()
    // {
    //     var list = _context.Items.ToListAsync();
    //     return await list;
    // }


    // public async Task<Item> GetItemAsync(int id)
    // {
    //     return await _context.Items.FirstOrDefaultAsync(i => i.Item_Id == id);
    // }

    // public async CreateItemAsync(Item item)
    // {
    //     _context.Items.Add(item);
    //     await _context.SaveChangesAsync();
    // } // this method is used to create a new item in db, it add 
    // //the item to the context and then saves the changes to db

    // public async UpdateItemAsync(Item item)
    // {
    //     _context.Entry(item).State = EntityState.Modified;
    //     await _context.SaveChangesAsync();
    // } // this method is used to update an item in db, it changes the state of 
    // //the item to modified and then saves the changes to db

    // public async UpdatePriceAsync(int id, double price)
    // {
    //     var item = _context.Items.Find(id);
    //     if (item != null)
    //     {
    //         item.Price = price;
    //         await _context.SaveChangesAsync();
    //     }
    // } // this method is used to update the price of an item in db,
    // // it finds the item by id,

    // public async DeleteItemAsync(int id)
    // {
    //     var item = _context.Items.Find(id);
    //     if (item != null)
    //     {
    //         _context.Items.Remove(item);
    //         await _context.SaveChangesAsync();
    //     }
    // } // this method is used to delete an item from db, it finds the item by id,




}
