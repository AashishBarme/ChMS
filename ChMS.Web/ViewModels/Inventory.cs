namespace ChMS.Web.ViewModels;
public  class CreateInventoryVM
{
    public string? Name {get; set;}
    public string? Code {get; set;}
    public string? Quantity {get; set;}
    public string? Description {get; set;}
    public IFormFile? ImageFile {get; set;}
}

public class EditInventoryVM : CreateInventoryVM
{
    public int Id {get; set;}   
    public string? Image {get; set;}
}