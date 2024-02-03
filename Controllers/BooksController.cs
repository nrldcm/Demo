using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DEMO.Models.DB;

namespace DEMO.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly demoContext _context;

		public BooksController(demoContext context)
		{
			_context = context;
		}

		// GET: api/Books
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Book>>> GetBooks(int page = 1, int pageSize = 10)
		{
			var books = await _context.Book
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			return books;
		}

		// GET: api/Books/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Book>> GetBook(long id)
		{
			var book = await _context.Book.FindAsync(id);

			if (book == null)
			{
				return NotFound();
			}

			return book;
		}

		// POST: api/Books
		[HttpPost]
		public async Task<ActionResult<Book>> PostBook(Book book)
		{
			// Check if a book with the same name already exists (excluding the original book being added)
			if (await BookExistsWithName(book.Title, 0))
			{
				return Conflict("A book with the same name already exists.");
			}

			_context.Book.Add(book);
			await _context.SaveChangesAsync();

			return Ok("Saved!");
		}

		// PUT: api/Books/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutBook(long id, Book book)
		{
			// Check if a book with the same name already exists (excluding the original book being updated)
			if (await BookExistsWithName(book.Title, id))
			{
				return Conflict("A book with the same name already exists.");
			}

			if (id != book.Id)
			{
				return BadRequest();
			}

			_context.Entry(book).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
				return Ok("Updated!"); // Update successful
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await BookExists(id))
				{
					return NotFound();
				}
				else
				{
					return StatusCode(500, "An error occurred while updating the book."); // Update failed
				}
			}
		}


		// DELETE: api/Books/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Book>> DeleteBook(long id)
		{
			var book = await _context.Book.FindAsync(id);
			if (book == null)
			{
				return NotFound();
			}

			_context.Book.Remove(book);
			await _context.SaveChangesAsync();

			return Ok("Deleted!");
		}

		private async Task<bool> BookExists(long id)
		{
			var isExist = await _context.Book.AnyAsync(e => e.Id == id);
			return isExist;
		}
		
		private async Task<bool> BookExistsWithName(string name, long idToExclude)
		{
			var isExist = await _context.Book.AnyAsync(e => e.Title == name && e.Id != idToExclude);
			return isExist;
		}
	}
}
