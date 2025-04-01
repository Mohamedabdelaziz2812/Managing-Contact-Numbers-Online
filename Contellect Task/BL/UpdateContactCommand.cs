namespace Contellect_Task.BL;
public class UpdateContactCommand : ICommand<int?>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public class Handler : ICommandHandler<UpdateContactCommand, int?>
    {
        private readonly IContactsDbContext _context;
        public Handler(IContactsDbContext context)
        {
            _context = context;
        }
        public async Task<Result<int?>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _context.Contacts.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

                if (contact is null)
                    return BaseErrors.NotFound;


                contact.Address = request.Address;
                contact.Name = request.Name;
                contact.Phone = request.Phone;
                await _context.SaveChangesAsync(cancellationToken);
                return contact.Id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
