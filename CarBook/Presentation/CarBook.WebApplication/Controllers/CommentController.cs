using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;
        private readonly IMediator _mediator;

        public CommentController(IGenericRepository<Comment> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values=_repository.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _repository.Create(comment);
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value = _repository.GetById(id);
            _repository.Remove(value);
            return Ok("Yorum başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok("Yorum başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _repository.GetById(id);
            return Ok(value);
        }
        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var value = _repository.GetCommentsByBlogId(id);
            return Ok(value);
        }
        [HttpGet("CommentCountByBlog")]
        public IActionResult CommentCountByBlog(int id)
        {
            var value = _repository.GetCountCommentByBlog(id);
            return Ok(value);
        }
        [HttpPost("CreateCommentMediator")]
        public async Task<IActionResult> CreateCommentMediator(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum başarılı bir şekilde eklendi");
        }
    }
}
