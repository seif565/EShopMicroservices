﻿
namespace Catalog.Api.Products.DeleteProduct
{
    //public record DeleteProductRequest(Guid Id);
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
                DeleteProductResult result = await sender.Send(new DeleteProductCommand(id));
                DeleteProductResponse response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            })
                .WithName("Delete Product")
                .WithSummary("Delete Product")
                .WithDescription("Delete Product")
                .Produces(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }
}
