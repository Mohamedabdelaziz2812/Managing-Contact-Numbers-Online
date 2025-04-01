namespace Contellect_Task.DTOs;

public class ContactDataTableDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public List<string> Notes { get; set; }
}