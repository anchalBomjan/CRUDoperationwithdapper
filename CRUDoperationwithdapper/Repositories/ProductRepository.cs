using CRUDoperationwithdapper.Data;
using CRUDoperationwithdapper.Models;
using Dapper;
using System;

namespace CRUDoperationwithdapper.Repositories
{
    public class ProductRepository:Iproduct
    {
        private readonly DapperDbContext _dbContext;
        public ProductRepository(DapperDbContext context)
        {
             _dbContext = context;
        }
        public async Task<IEnumerable<ProductModel>> Get()
        {
            var sql = $@"SELECT [ProductId],
                               [ProductName],
                               [Price],
                               [ProductDescription],
                               [CreatedOn],
                               [UpdateOn]
                            FROM
                               [Products]";

            using var connection = _dbContext.CreateConnection();
            return await connection.QueryAsync<ProductModel>(sql);
        }
        public async Task<ProductModel> Find(Guid uid)
        {
            var sql = $@"SELECT [ProductId],
                               [ProductName],
                               [Price],
                               [ProductDescription],
                               [CreatedOn],
                               [UpdateOn]
                            FROM
                               [Products]
                            WHERE
                              [ProductId]=@uid";

            using var connection = _dbContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ProductModel>(sql, new { uid });
        }
        public async Task<ProductModel> Add(ProductModel model)
        {
            model.ProductId = Guid.NewGuid();
            model.CreatedOn = DateTime.Now;
            var sql = $@"INSERT INTO [dbo].[Products]
                                ([ProductId],
                                 [ProductName],
                                 [Price],
                                 [ProductDescription],
                                 [CreatedOn])
                                VALUES
                                (@ProductId,
                                 @ProductName,
                                 @Price,
                                 @ProductDescription,
                                 @CreatedOn)";

            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(sql, model);
            return model;
        }
        public async Task<ProductModel> Update( ProductModel model)
        {
            model.UpdateOn = DateTime.Now;
            var sql = $@"UPDATE[dbo].[Products]
                           SET [ProductId] = @ProductId,
                               [ProductName] = @ProductName,
                               [Price] = @Price,
                               [ProductDescription] = @ProductDescription,
                               [UpdateOn] = @UpdateOn
                          WHERE
                              ProductId=@ProductId";

            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(sql, model);
            return model;
        }
        public async Task<ProductModel> Remove(ProductModel model)
        {
            var sql = $@"
                        DELETE FROM
                            [dbo].[Products]
                        WHERE
                            [ProductId]=@ProductId";
            using var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(sql, model);
            return model;
        }


    }
}
