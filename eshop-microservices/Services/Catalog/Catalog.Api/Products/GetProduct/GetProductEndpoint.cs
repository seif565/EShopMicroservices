
namespace Catalog.Api.Products.GetProduct
{

    // public record GetProductRequest();

    public record GetProductResponse(IEnumerable<Product> Products);

    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {                
                GetProductsResult result = await sender.Send(new GetProductsQuery());
                
                GetProductResponse response = result.Adapt<GetProductResponse>();

                return Results.Ok(response);
            })
                .WithName("Get Products")
                .WithDescription("Get Products")
                .WithSummary("GetProducts")
                .Produces(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status404NotFound);           
        }
    }
}
