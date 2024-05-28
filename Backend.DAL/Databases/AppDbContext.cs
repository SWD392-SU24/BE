namespace Backend.DAL.Databases
{
    public partial class AppDbContext : DenticareContext
    {
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //TODO: Implement auditing handler
            return base.SaveChangesAsync(cancellationToken);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    );
        //}
    }
}
