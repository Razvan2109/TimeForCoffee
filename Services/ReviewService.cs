using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models;
using TimeForCoffee.Models.DTOs;
using TimeForCoffee.Repository.CafeRepository;
using TimeForCoffee.Repository.ReviewRepository;
using TimeForCoffee.Repository.UserRepository;


namespace TimeForCoffee.Services
{
    public class ReviewService:IReviewService
    {
        public ICafeRepository _cafeRepository;
        public IReviewRepository _reviewRepository;
        public IUserRepository _userRepository;

        public ReviewService(ICafeRepository cafeRepository, IReviewRepository reviewRepository, IUserRepository userRepository)
        {
            _cafeRepository = cafeRepository;
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }

        public ReviewDTO CreateReview(ReviewDTO reviewToCreate)
        {
            User commentingUser = _userRepository.GetByUsername(reviewToCreate.Username);
            Cafe reviewedCafe = _cafeRepository.GetByName(reviewToCreate.Cafe);
            Review newReview = new Review
            {
                DateModified = DateTime.Now,
                UserId = commentingUser.Id,
                CafeId = reviewedCafe.Id,
                score = reviewToCreate.Score,
                Text = reviewToCreate.Text
            };

            _reviewRepository.Create(newReview);
            _reviewRepository.Save();

            User usercomm = _userRepository.FindById(newReview.UserId);
            Cafe cafecomm = _cafeRepository.FindById(newReview.CafeId);


            ReviewDTO added = new ReviewDTO
            {
                Username = usercomm.Username,
                Cafe = cafecomm.Name,
                Score = newReview.score,
                Text = newReview.Text
            };

            return added;
        }

        public List<ReviewDTO> DeleteReviews(string name, string cafe)
        {
            List<ReviewDTO> toShow = new List<ReviewDTO>();
            List<Review> toDelete = new List<Review>();
            toDelete = _reviewRepository.GetReviewsByUserToCafe(name, cafe);
            foreach (Review delRev in toDelete)
            {
                User userTemp = _userRepository.FindById(delRev.UserId);
                Cafe cafeTemp = _cafeRepository.FindById(delRev.CafeId);
                ReviewDTO temp = new ReviewDTO
                {
                    Username = userTemp.Username,
                    Cafe = cafeTemp.Name,
                    Score = delRev.score,
                    Text = delRev.Text

                };
                toShow.Add(temp);
            }

            _reviewRepository.DeleteRange(toDelete);
            _reviewRepository.Save();

            return toShow;
        }

        public List<ReviewDTO> GetAllReviewsForCafe(string cafe)
        {
            List<ReviewDTO> toShow = new List<ReviewDTO>();
            List<Review> reviews = new List<Review>();
            reviews = _reviewRepository.GetAllReviewsForCafe(cafe);
            foreach(Review review in reviews)
            {
                User userTemp = _userRepository.FindById(review.UserId);
                Cafe cafeTemp = _cafeRepository.FindById(review.CafeId);
                ReviewDTO temp = new ReviewDTO
                {
                    Username = userTemp.Username,
                    Cafe = cafeTemp.Name,
                    Score = review.score,
                    Text = review.Text
                };
                toShow.Add(temp);
            }

            return toShow;

        }

        public List<ReviewDTO> UpdatePreviousReviews(string name, string cafe, string text, int score)
        {
            List<ReviewDTO> toShow = new List<ReviewDTO>();
            List<Review> toUpdate = new List<Review>();
            toUpdate = _reviewRepository.GetReviewsByUserToCafe(name, cafe);
            foreach (Review upRev in toUpdate)
            {
                
                User userTemp = _userRepository.FindById(upRev.UserId);
                Cafe cafeTemp = _cafeRepository.FindById(upRev.CafeId);
                upRev.score = score;
                upRev.Text = text;
                ReviewDTO temp = new ReviewDTO
                {
                    Username = userTemp.Username,
                    Cafe = cafeTemp.Name,
                    Score = upRev.score,
                    Text = upRev.Text

                };
                toShow.Add(temp);
            }

            _reviewRepository.UpdateRange(toUpdate);
            _reviewRepository.Save();

            return toShow;
        }
    }
}
