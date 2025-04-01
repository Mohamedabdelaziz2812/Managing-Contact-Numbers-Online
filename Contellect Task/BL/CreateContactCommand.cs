namespace Contellect_Task.BL;
public class CreateContactCommand : ICommand<int?>
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Notes { get; set; }
    public class Handler : ICommandHandler<CreateContactCommand, int?>
    {
        private readonly IContactsDbContext _context;
        public Handler(IContactsDbContext context)
        {
            _context = context;
        }
        public async Task<Result<int?>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Contact = new Contact
                {
                    Name = request.Name,
                    Phone = request.Phone,
                    Address = request.Address,
                    //Notes = request.Notes
                };

                _context.Contacts.Add(Contact);
                await _context.SaveChangesAsync(cancellationToken);
                return Contact.Id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
