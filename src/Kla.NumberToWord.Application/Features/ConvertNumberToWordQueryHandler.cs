using Kla.NumberToWord.Core.Domain;
using MediatR;

namespace Kla.NumberToWord.Application.Features;

public class ConvertNumberToWordQueryHandler : IRequestHandler<ConvertNumberToWordQuery, ConvertNumberToWordQueryResponse>
{
    private readonly INumberToWordConvertor _convertor;

    public ConvertNumberToWordQueryHandler(INumberToWordConvertor convertor)
    {
        _convertor = convertor;
    }

    public Task<ConvertNumberToWordQueryResponse> Handle(ConvertNumberToWordQuery request, CancellationToken cancellationToken)
    {
        var word = _convertor.Convert(request.Input);

        var result = new ConvertNumberToWordQueryResponse(word);

        return Task.FromResult(result);
    }
}