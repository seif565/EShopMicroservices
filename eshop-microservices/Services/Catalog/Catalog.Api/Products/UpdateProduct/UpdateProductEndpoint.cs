namespace Catalog.Api.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record UpdateProductResponse(Product product);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
            {
                UpdateProductCommand command = request.Adapt<UpdateProductCommand>();
                UpdateProductResult result = await sender.Send(command);
                return Results.NoContent();
            })
                .WithName("UpdateProduct Endpoint")
                .WithSummary("UpdateProduct Endpoint")
                .WithDescription("UpdateProduct Endpoint")
                .Produces(StatusCodes.Status204NoContent)
                .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
