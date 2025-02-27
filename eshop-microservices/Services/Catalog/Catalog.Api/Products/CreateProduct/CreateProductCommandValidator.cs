namespace Catalog.Api.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category should not be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image file should not be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description should not be empty");
            RuleFor(x => x.Price).Must(x => x > 0).WithMessage("Price must be greater than 0");
        }
    }
}
