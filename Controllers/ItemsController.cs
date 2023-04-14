using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2.Database;
using Assignment2.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace Assignment2.Controllers
{

	public class ItemsController : Controller
	{
		private readonly Assign2DBContext _context;

		public ItemsController(Assign2DBContext context)
		{
			_context = context;
		}

        // GET: Items
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            var item = from i in _context.Items
                       select i;
            if (!String.IsNullOrEmpty(SearchString))
            {
                item = item.Where(i => i.Name.Contains(SearchString) || i.Category.Contains(SearchString));
            }
            return View(item);
        }


        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

			var item = await _context.Items
				.FirstOrDefaultAsync(m => m.Id == id);
			if (item == null)
			{
				return NotFound();
			}

			return View(item);
		}

		// GET: Items/Create
		[Authorize]
		public IActionResult Create()
		{
			return View();
		}

		// POST: Items/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Description,MinimumBid,StartBidDate,EndBidDate,Condition,Category,ItemPicture")] Item item, IFormFile file)
		{
			if (ModelState.IsValid)
			{
				if (file != null && file.Length > 0)
				{
					using (var dataStream = new MemoryStream())
					{
						await file.CopyToAsync(dataStream);
						item.ItemPicture = dataStream.ToArray();
					}
				}

				_context.Add(item);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			else
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors);
				foreach (var modelState in ModelState.Values)
				{
					foreach (var error in modelState.Errors)
					{
						Console.WriteLine($"Error: {error.ErrorMessage}");
					}
				}
			}
			return View(item);
		}

		// GET: Items/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Items == null)
			{
				return NotFound();
			}

			var item = await _context.Items.FindAsync(id);
			if (item == null)
			{
				return NotFound();
			}
			return View(item);
		}

		// POST: Items/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,MinimumBid,StartBidDate,EndBidDate,Condition,Category,ItemPicture")] Item item, IFormFile file)
		{
			if (id != item.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					if (file != null && file.Length > 0)
					{
						using (var dataStream = new MemoryStream())
						{
							await file.CopyToAsync(dataStream);
							item.ItemPicture = dataStream.ToArray();
						}
					}

					_context.Update(item);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ItemExists(item.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				
			}
			return View(item);
		}

		// GET: Items/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Items == null)
			{
				return NotFound();
			}

			var item = await _context.Items
				.FirstOrDefaultAsync(m => m.Id == id);
			if (item == null)
			{
				return NotFound();
			}

			return View(item);
		}

		// POST: Items/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Items == null)
			{
				return Problem("Entity set 'Assign2DBContext.Items'  is null.");
			}
			var item = await _context.Items.FindAsync(id);
			if (item != null)
			{
				_context.Items.Remove(item);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ItemExists(int id)
		{
			return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
		}


	}
}
