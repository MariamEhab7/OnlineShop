using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class PersonalRepo : GenericRepo<PersonalDetails>, IPersonalRepo
{
    private readonly ShopContext _context;

    public PersonalRepo(ShopContext context) : base(context)
    {
        _context = context;
    }
}
