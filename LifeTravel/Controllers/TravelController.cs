using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using LifeTravel.Models;
namespace LifeTravel.Controllers
{
    public class TravelController : Controller
    {
        private string connect = "Server=localhost\\SQLEXPRESS;Database=LifeOfTravel;Integrated Security=True;";

        // Display form
        public ActionResult Index()
        {
            return View();
        }

        // Handle form submission
        [HttpPost]
        public ActionResult Index( LifeOfTravel model , HttpPostedFileBase photo, HttpPostedFileBase video)
        {
            if (ModelState.IsValid)
            {
                // Handle the photo and video uploads (same logic as before)
                if (photo != null && photo.ContentLength > 0)
                {
                    string photoFileName = Path.GetFileName(photo.FileName);
                    string photoPath = Path.Combine(Server.MapPath("~/Uploads/Images"), photoFileName);
                    photo.SaveAs(photoPath);
                    model.Photo = "/Uploads/Images/" + photoFileName;  // Store the relative file path in the model
                }

                if (video != null && video.ContentLength > 0)
                {
                    string videoFileName = Path.GetFileName(video.FileName);
                    string videoPath = Path.Combine(Server.MapPath("~/Uploads/Videos"), videoFileName);
                    video.SaveAs(videoPath);
                    model.Video = "/Uploads/Videos/" + videoFileName;  // Store the relative file path in the model
                }

                // Insert data into the database (same as before)
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO LifeOfTravel (Name, Email, City, FoodPreference, PhoneNumber, Comments, Photo, Video) VALUES (@Name, @Email, @City, @FoodPreference, @PhoneNumber, @Comments, @Photo, @Video)", conn);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@FoodPreference", model.FoodPreference);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Comments", model.Comments);
                    cmd.Parameters.AddWithValue("@Photo", model.Photo);  // Store the file path in the database
                    cmd.Parameters.AddWithValue("@Video", model.Video);  // Store the file path in the database

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Set success message in TempData
                TempData["SuccessMessage"] = "Form submitted successfully!";

                // Redirect back to the form view with the success message
                return RedirectToAction("Index");
            }

            // If the model is invalid, return to the form with validation errors
            return View(model);
        }

    }


}

