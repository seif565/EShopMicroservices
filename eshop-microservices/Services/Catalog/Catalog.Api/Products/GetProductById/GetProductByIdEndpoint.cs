
namespace Catalog.Api.Products.GetProductById
{
    //public record GetProductByIdRequest();
    public record GetProductByIdResponse(Product product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                GetProductByIdResult result = await sender.Send(new GetProductByIdQuery(id));
                GetProductByIdResponse response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            })
            .WithDescription("Get Product By Id")
            .WithName("Get Product By Id")
            .WithSummary("Get Product By Id")
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }
}
