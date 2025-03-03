
namespace Catalog.Api.Products.GetProducts
{

    public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);

    public record GetProductsResponse(IEnumerable<Product> Products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
            {                
                GetProductsQuery query = request.Adapt<GetProductsQuery>();
                
                GetProductsResult result = await sender.Send(query);
                
                GetProductsResponse response = result.Adapt<GetProductsResponse>();

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
