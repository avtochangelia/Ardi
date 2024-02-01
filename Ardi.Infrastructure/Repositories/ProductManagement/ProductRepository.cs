using Ardi.Domain.ProductManagement;
using Ardi.Domain.ProductManagement.Repositories;
using Ardi.Infrastructure.DataAccess;

namespace Ardi.Infrastructure.Repositories.ProductManagement;

public class ProductRepository(EFDbContext efDbContext, DapperDbContext dapperContext) 
    : BaseRepository<Product>(efDbContext, dapperContext), IProductRepository
{
}