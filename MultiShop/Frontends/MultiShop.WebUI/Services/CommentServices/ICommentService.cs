using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices;

public interface ICommentService
{
    Task<List<ResultCommentDto>> GetAllCommentAsync();
    Task<GetByIdCommentDto> GetByIdCommentAsync(string id);
    Task<List<ResultCommentDto>> CommentListByProductId(string id);
    Task CreateCommentAsync(CreateCommentDto createCommentDto);
    Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
    Task DeleteCommentAsync(string id);
}
