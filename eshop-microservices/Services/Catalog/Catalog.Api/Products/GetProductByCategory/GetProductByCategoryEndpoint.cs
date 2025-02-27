
namespace Catalog.Api.Products.GetProductByCategory
{
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        //public record GetProductByCategoryRequest();
        public record GetProductByCategoryResponse(IEnumerable<Product> Products);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                GetProductByCategoryResult result = await sender.Send(new GetProductByCategoryQuery(category));
                GetProductByCategoryResponse response = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);
            })
            .WithName("Get ProductByCategory")
            .WithSummary("Get Product By Category")
            .WithDescription("Get Product By Category")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
