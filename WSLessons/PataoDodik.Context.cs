//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSLessons
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PataoDodikEntities1 : DbContext
    {
        private static PataoDodikEntities1 _context;
        public PataoDodikEntities1()
            : base("name=PataoDodikEntities1")
        {
        }

        public static PataoDodikEntities1 GetContext()
        {
            if (_context == null)
            {
                _context = new PataoDodikEntities1();
            }
            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Raw> Raw { get; set; }
    }
}
