using CleanArchitecture.Shared.Models;
using CleanArchitecture.Shared.Models.Book;
using MediatR;

namespace CleanArchitecture.Application.Features.Books.Queries;

public record SearchBooksByTitleQuery(string Title, int PageIndex = 0, int PageSize = 10) : IRequest<Pagination<BookDTO>>;