using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Shared.Models;
using CleanArchitecture.Shared.Models.Book;
using MediatR;

namespace CleanArchitecture.Application.Features.Books.Queries;

public record SearchBooksByTitleQuery(string Title, int PageIndex = 0, int PageSize = 10) : IRequest<Pagination<BookDTO>>;
public class SearchBooksByTitleQueryHandler : IRequestHandler<SearchBooksByTitleQuery, Pagination<BookDTO>>
{
    private readonly IBookService _bookService;

    public SearchBooksByTitleQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<Pagination<BookDTO>> Handle(SearchBooksByTitleQuery request, CancellationToken cancellationToken)
    {
        return await _bookService.SearchByTitle(request.Title, request.PageIndex, request.PageSize, cancellationToken);
    }
}