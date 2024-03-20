using MediatR;

namespace Kla.NumberToWord.Application.Features;

public class ConvertNumberToWordQueryHandler:IRequestHandler<ConvertNumberToWordQuery,ConvertNumberToWordQueryResponse>
{
    public ConvertNumberToWordQueryHandler()
    {
        
    }
    public Task<ConvertNumberToWordQueryResponse> Handle(ConvertNumberToWordQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}