
namespace Contellect_Task.Data;

public class Contact
{
    public Contact()
    {
        Notes = [];
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public ICollection<ContactNote> Notes { get; set; }
}
