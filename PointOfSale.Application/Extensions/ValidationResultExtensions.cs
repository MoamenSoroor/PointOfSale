using FluentValidation;
using FluentValidation.Results;
using MediatR;
using PointOfSale.Application.Exceptions;
using PointOfSale.Application.Responses;

namespace PointOfSale.Application.Extensions
{
    public static class ValidationResultExtensions
    {
        public static ValidationResult ThrowValidationExceptionOnFailure(this ValidationResult validationResult)
        {

            if (!validationResult.IsValid)
                throw new CustomValidationException(validationResult);
            return validationResult;
        }

        public static BaseResponse ToResponse(this ValidationResult validationResult)
        {
            BaseResponse response = new BaseResponse()
            {
                Success = validationResult.IsValid,
                ValidationErrors = validationResult.Errors?.Select(err => err.ErrorMessage).ToList()
            };
            return response;
        }

        public static T ToResponse<T>(this ValidationResult validationResult) where T : BaseResponse, new()
        {
            T response = new T()
            {
                Success = validationResult.IsValid,
                ValidationErrors = validationResult.Errors?.Select(err => err.ErrorMessage).ToList()
            };
            return response;
        }

    }


    //public static class ValidationExtensions
    //{
    //    public static async Task<TResponse> ValidateAsync<TResponse, TCommand, TValidator>(this TCommand request ) 
    //        where TResponse : BaseResponse, new()
    //        where TValidator : AbstractValidator<TCommand>, new()
    //        where TCommand : IRequest<TCommand>
    //    {
    //        if(request == null ) throw new ArgumentNullException(nameof(request));
    //        var validator = new TValidator();
    //        var validationResult = await validator.ValidateAsync(request);

    //        var response = validationResult.ToResponse<TResponse>();

    //        return response;
    //    }


    //    public static TResponse Validate<TResponse, TCommand, TValidator>(this TCommand request)
    //        where TResponse : BaseResponse, new()
    //        where TValidator : AbstractValidator<TCommand>, new()
    //        where TCommand : IRequest<TCommand>
    //    {

    //        if (request == null) throw new ArgumentNullException(nameof(request));
    //        var validator = new TValidator();
    //        var validationResult = validator.Validate(request);

    //        var response = validationResult.ToResponse<TResponse>();

    //        return response;

    //    }

    //}

}
