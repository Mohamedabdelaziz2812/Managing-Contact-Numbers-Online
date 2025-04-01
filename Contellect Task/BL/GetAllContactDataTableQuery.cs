namespace Contellect_Task.BL;
public class GetAllContactDataTableQuery : IQuery<DataTableDto<ContactDataTableDTO>>
{
    public int? draw { get; set; }
    public int start { get; set; } // Skip 
    public int length { get; set; } // Page Size
    public List<Order> order { get; set; }
    public Search search { get; set; }
    public List<Columns> columns { get; set; }
    public class Handler : IQueryHandler<GetAllContactDataTableQuery, DataTableDto<ContactDataTableDTO>>
    {
        private readonly IContactsDbContext _context;
        public Handler(IContactsDbContext context)
        {
            _context = context;
        }
        public async Task<Result<DataTableDto<ContactDataTableDTO>>> Handle(GetAllContactDataTableQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int skip = request.start != 0 ? request.start : 0;
                int pageSize = request.length != 0 ? request.length : 10;
                int recordsTotal = 0;
                string dir = request.order.FirstOrDefault().dir;
                int Column = request.order.FirstOrDefault().Column;

                var query = _context.Contacts.AsQueryable();

                if (!string.IsNullOrEmpty(request.search.Value))
                    query = query.Where(x => x.Name.ToLower().Contains(request.search.Value.ToLower())
                        || x.Phone.ToLower().Contains(request.search.Value.ToLower())
                        || x.Address.ToLower().Contains(request.search.Value.ToLower()));

                var strategicObjectives = await query
                    .Select(a => new ContactDataTableDTO
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Address = a.Address,
                        Phone = a.Phone
                    })
                    //.OrderBy(request.columns[Column].data + " " + dir)
                    .Skip(skip)
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);

                recordsTotal = await query.CountAsync(cancellationToken);
                return new DataTableDto<ContactDataTableDTO>
                {

                    draw = request.draw,
                    data = strategicObjectives,
                    recordsTotal = recordsTotal,
                    recordsFiltered = recordsTotal
                };
            }
            catch (Exception ex)
            {
                return null;

                //return GlobalExceptionHandler.Handle<GetAllContactDataTableQuery, Result<DataTableDto<ContactDataTableDTO>>>(ex, request);

            }
        }
    }
}
