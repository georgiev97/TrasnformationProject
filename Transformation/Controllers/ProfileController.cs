using Data.Entity;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transformation.ViewModel;
using System.Data.Entity;
namespace Transformation.Controllers
{
    public class ProfileController : BaseController
    {

        private UserRepository userRepository = null;
        private TrainingUserRepository trainingUser = null;
        private WorkoutRepository workoutRepository = null;

        public ProfileController()
        {
            userRepository = new UserRepository(Context);
            trainingUser = new TrainingUserRepository(Context);
            workoutRepository = new WorkoutRepository(Context);

        }


        [HttpGet]
        public ActionResult TopUsers(string id)
        {
            var user = userRepository.IsUsernameExist(id);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            List<TrainingUser> users = trainingUser.getAll();
        

             var model = new TopUsers { Users = users, User = user };


            return View(model);
        }

        [HttpGet]
        public ActionResult Rating(string id)
        {
            var user = userRepository.IsUsernameExist(id);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Rating(string id,double rating)
        {
            rating = rating + 0.5 ;
            var user = userRepository.IsUsernameExist(id);
            user.TrainingUser.Rating = rating;
            trainingUser.Update(user.TrainingUser);

            return RedirectToAction("Rating","Profile", new { id = user.Username });
        }

        [HttpGet]
        public ActionResult CreateWorkout(string id)
        {
            var user = userRepository.IsUsernameExist(id);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult CreateWorkout(Workout workout)
        {

           var user = userRepository.GetById(workout.UserId);
           workout.User = user;
            if (user !=null)
            {
                workoutRepository.AddOrUpdate(workout);
            }
            else
            {
                workoutRepository.Add(workout);
            }
           
             return RedirectToAction("Workout","Profile", new { id=user.Username });
        }

        [HttpGet]
        public ActionResult Workout(string id)
        {
            var user = userRepository.IsUsernameExist(id);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Nutrition(string id)
        {
            var user = userRepository.IsUsernameExist(id);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Nutrition(string id, int nutrition)
        {
            var user = userRepository.IsUsernameExist(id);



            return RedirectToAction("Nutrition", "Profile", new { id = user.Username });
        }

    }
}