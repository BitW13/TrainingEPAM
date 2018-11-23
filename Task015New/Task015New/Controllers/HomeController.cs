using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task015New.Models;
using Task015New.Models.Repository;

namespace Task015New.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _context;

        public HomeController()
        {
            _context = new UserRepository();
        }
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            var users = _context.GetAll().ToList();
            return View(users.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Index(string action, string selectedItem)
        {
            if (action == "Add")
            {
                ViewBag.AddOrUpdate = "Add";
                return View("AddOrUpdate");
            }
            else if (action == "Update" && selectedItem!=null)
            {
                ViewBag.AddOrUpdate = "Update";
                return View("AddOrUpdate", _context.GetElementById(Convert.ToInt32(selectedItem)));
            }
            else if (action == "Remove")
            {
                Remove(Convert.ToInt32(selectedItem));
            }

            return View((_context.GetAll().ToList()).ToPagedList(1, 2));
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            if (id > 0)
            {
                _context.Delete(id);
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult AddOrUpdate(int? id)
        {
            if (id == 0)
            {
                ViewBag.AddOrUpdate = "Add";
                return View();
            }
            else
            {
                ViewBag.AddOrUpdate = "Update";
                return View(_context.GetElementById(id.Value));
            }

        }
        [HttpPost]
        public ActionResult AddOrUpdate(User user)
        {
            var oldUser = _context.GetElement(user);
            if (oldUser != null)
            {
                if (ModelState.IsValidField("Name") && ModelState.IsValidField("MiddleName") && ModelState.IsValidField("LastName") && ModelState.IsValidField("Age") &&
                    ModelState.IsValidField("Phone") && ModelState.IsValidField("Address"))
                {
                    var newUser = new User()
                    {
                        Name = user.Name,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        Email = oldUser.Email,
                        Password = oldUser.Password,
                        ReEnterPassword = oldUser.ReEnterPassword,
                        Id = user.Id,
                        Phone = user.Phone,
                        Age = user.Age,
                        Address = user.Address
                    };
                    _context.Update(newUser);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(user);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (user.Password == user.ReEnterPassword)
                    {
                        _context.Create(user);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Пароли не совпадают");
                        return View(user);
                    }
                }
            }
            return View(user);
        }

        public ActionResult TableData(string search, int? page)
        {           
            if (search == null)
            {
                int pageSize = 2;
                int pageNumber = (page ?? 1);
                var users = _context.GetAll().ToList();
                return PartialView(users.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var users = _context.GetAll();
                List<User> selectedUsers = new List<User>();

                foreach (var user in users)
                {
                    if (user.Name == search || user.MiddleName == search || user.LastName == search || user.Phone == search || (user.Age).ToString() == search ||
                        user.Email == search || user.Address == search)
                    {
                        selectedUsers.Add(user);
                    }
                }

                return PartialView(selectedUsers);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}