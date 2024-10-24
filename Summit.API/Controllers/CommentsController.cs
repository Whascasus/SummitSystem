using Microsoft.AspNetCore.Mvc;
using Summit.Domain.Interfaces;

namespace Summit.API.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("FillData")]
        public async Task<IActionResult> FillData()
        {
            try
            {
                await _commentService.FillData();
                return Ok("Datos encontrados");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("getData/(n)")]
        public IActionResult GetData(int n)
        {
            try
            {
               var data = _commentService.GetData(n);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("searchData")]
        public IActionResult SearchData(int id, string domain)
        {
            try
            {
                var result = _commentService.SerchData(id, domain);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
