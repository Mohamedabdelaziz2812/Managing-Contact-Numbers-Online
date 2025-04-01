namespace Contellect_Task.BL;
public class DeleteContactCommand : ICommand<int?>
{
    public int Id { get; set; }
    public class Handler : ICommandHandler<DeleteContactCommand, int?>
    {
        private readonly IContactsDbContext _context;
        public Handler(IContactsDbContext context)
        {
            _context = context;
        }
        public async Task<Result<int?>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var conatct = await _context.Contacts.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

                if (conatct is null)
                    return BaseErrors.NotFound;


                _context.Contacts.Remove(conatct);
                await _context.SaveChangesAsync(cancellationToken);
                return conatct.Id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}