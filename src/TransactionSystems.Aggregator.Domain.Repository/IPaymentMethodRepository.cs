using TransactionSystems.Aggregator.Domain.Entities;

namespace TransactionSystems.Aggregator.Domain.Repository
{
    public interface IPaymentMethodRepository
    {
        Task<PaymentMethod?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<PaymentMethod>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<PaymentMethod?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task AddAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken = default);

        void Update(PaymentMethod paymentMethod);

        void Delete(PaymentMethod paymentMethod);
    }
}
