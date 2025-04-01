namespace Contellect_Task.Data;

public class ContactNote
{
    public int Id { get; set; }
    public string Note { get; set; }
    public int ContactId { get; set; }
    public virtual Contact Contact { get; set; }

}