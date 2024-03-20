using MediatR;

namespace Kla.NumberToWord.Application.Features;

public record ConvertNumberToWordQuery(string Input) : IRequest<ConvertNumberToWordQueryResponse>;