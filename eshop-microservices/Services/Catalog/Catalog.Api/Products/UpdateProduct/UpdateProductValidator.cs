namespace Catalog.Api.Products.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id should not be empty");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category should not be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty")
                .Length(2,150).WithMessage("Name length must be between 2 and 150 characters");            
            RuleFor(x => x.Price).Must(x => x > 0).WithMessage("Price must be greater than 0");
        }
    }
}
