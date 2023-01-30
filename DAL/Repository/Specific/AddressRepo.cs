using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class AddressRepo : GenericRepo<Address>, IAddressRepo
{
    private readonly ShopContext _context;

    public AddressRepo(ShopContext context) : base(context)
    {
        _context = context;
    }
}
