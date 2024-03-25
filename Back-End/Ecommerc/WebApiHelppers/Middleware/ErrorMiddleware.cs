using System.Net;
using System.Text.Json;
using Application.Exceptions;
using Domain.Entites.Erro;
using Domain.Excecoes;
using FluentValidation;
using Microsoft.AspNetCore.Http;
namespace Middleware;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var result = new ErroResult();

            var response = context.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case ValidationException:
                    foreach (var validationError in (error as ValidationException).Errors)
                    {
                        result.AdicionarErro(validationError.ErrorMessage);
                    }
                    break;
                case RegistroNaoEncontradoException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result.AdicionarErro(error.Message);
                    break;
                case ValidatorException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result.AdicionarErro(error.Message);
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result.AdicionarErro(error.Message);
                    break;
            }

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            await response.WriteAsync(JsonSerializer.Serialize(result, serializeOptions));
        }
    }
}
