﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2_NicolasRodriguez.Data;
using Parcial2_NicolasRodriguez.Models;

namespace Parcial2_NicolasRodriguez.Controllers
{
    public class FriendsController : Controller
    {
        private readonly AppDbContext _context;

        public FriendsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Friends
        public async Task<IActionResult> Index()
        {
            return View(await _context.Friend.ToListAsync());
        }

        // GET: Friends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friend
                .FirstOrDefaultAsync(m => m.FriendId == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // GET: Friends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendId,Name,Nickname,Birthday")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(friend);
        }

        // GET: Friends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friend.FindAsync(id);
            if (friend == null)
            {
                return NotFound();
            }
            return View(friend);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FriendId,Name,Nickname,Birthday")] Friend friend)
        {
            if (id != friend.FriendId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendExists(friend.FriendId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(friend);
        }

        // GET: Friends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friend
                .FirstOrDefaultAsync(m => m.FriendId == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var friend = await _context.Friend.FindAsync(id);
            _context.Friend.Remove(friend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendExists(int id)
        {
            return _context.Friend.Any(e => e.FriendId == id);
        }
    }
}
