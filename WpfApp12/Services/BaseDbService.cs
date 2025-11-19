using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfApp12.Data;

namespace WpfApp12.Services
{
    public class BaseDbService
    {
        private static BaseDbService? _instance;
        public static BaseDbService Instance => _instance ??= new BaseDbService();

        public AppDbContext Context { get; }

        private BaseDbService()
        {
            Context = new AppDbContext();
        }
    }
}
