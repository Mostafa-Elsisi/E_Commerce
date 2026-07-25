namespace E_Commerce.Domain.Contracts
{
    public interface IDataSeeder
    {
        Task SeedDataAsyc(CancellationToken ct = default);

    }
}
