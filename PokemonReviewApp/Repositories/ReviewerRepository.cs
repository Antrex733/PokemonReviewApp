﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repositories.Interfaces;

namespace PokemonReviewApp.Repositories
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly IMapper _mapper;
        private readonly PokemonDbContext _context;

        public ReviewerRepository(IMapper mapper, PokemonDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public bool CreateReviewer(Reviewer reviewer)
        {
            _context.Add(reviewer);
            return Save();
        }

        public bool DeleteReviewer(Reviewer reviewer)
        {
            _context.Remove(reviewer);
            return Save();
        }

        public Reviewer GetReviewer(int Id)
        {
            var reviewer = _context.Reviewers
                .Where(x => x.Id == Id)
                .Include(e => e.Reviews)
                .FirstOrDefault();
            return reviewer;
        }

        public ICollection<Reviewer> GetReviewers()
        {
            var reviewers = _context.Reviewers.ToList();
            return reviewers;
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            var reviews = _context.Reviews
                .Where(r => r.Reviewer.Id == reviewerId)
                .ToList();
            return reviews;
        }

        public bool ReviewerExists(int Id)
        {
            return _context.Reviewers.Any(x => x.Id == Id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UpdateReviewer(Reviewer reviewer)
        {
            _context.Update(reviewer);
            return Save();
        }
    }
}
