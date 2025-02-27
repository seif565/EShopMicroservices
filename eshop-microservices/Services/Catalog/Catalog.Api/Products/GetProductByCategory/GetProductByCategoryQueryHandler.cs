namespace Catalog.Api.Products.GetProductByCategory
{
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
    internal class GetProductByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductByCategoryQuery> logger) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByCategoryQueryHandler.Handle called with {@Query}", query);
            IReadOnlyList<Product> products = await session.Query<Product>().Where(x => x.Category.Contains(query.Category)).ToListAsync(cancellationToken);
            return new GetProductByCategoryResult(products);
        }
    }
}
