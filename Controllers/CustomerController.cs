using crud_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crud_app.Controllers;

public class CustomerController(CrudApplicationContext db): Controller
{
    private readonly CrudApplicationContext _db = db;
    public IActionResult Index()
        => View(_db.Customers.ToList());
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [Authorize]
    public IActionResult Create(Customer customer)
    {
        if (_db.Customers.Any(cust => cust.Email!.Equals(customer.Email)))
        {
            ModelState.AddModelError("email","this email already exists");
        }
        if (ModelState.IsValid)
        {
            Console.Write(customer.Id);
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();
    }
    [Authorize]
    public IActionResult Delete(int id)
    {
        _db.Customers.Remove(_db.Customers.First(customer => customer.Id.Equals(id)));
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [Authorize]
    public IActionResult Edit(int id)
    {
        var customer = _db.Customers.Find(id);
        if (customer is null)
        {
            return NotFound();
        }

        return View(customer);
    }
    [Authorize]
    [HttpPost]
    public IActionResult Edit(Customer customer)
    {
        if (_db.Customers
            .Any(cust => cust.Email!.Equals(customer.Email)
                         && !customer.Id.Equals(customer.Id)))
        {
            ModelState.AddModelError("email","this email already exists");
        }

        if (ModelState.IsValid)
        {
            _db.Customers.Update(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();
    }
    
}