using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Linq.Expressions;
using DeviceManagement_WebApp.Interface;
using DeviceManagement_WebApp.Generic;
using DeviceManagement_WebApp.Repositories;



public class ZoneRepository : IZoneRepository
{

    private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

    public void Add(Zone entity)
    {
        _context.Set<Zone>().Add(entity);
    }

    public void AddRange(IEnumerable<Zone> entities)
    {
        _context.Set<Zone>().AddRange(entities);
    }

    public IEnumerable<Zone> Find(Expression<Func<Zone, bool>> expression)
    {
        return _context.Set<Zone>().Where(expression);
    }

    public IEnumerable<Zone> GetAll()
    {
        //return _context.Set<T>().ToList();  
        return _context.Zone.ToList();
    }

    public Zone GetById(Guid? id)
    {
        //return _context.Set<T>().Find(id); 
        return _context.Zone.Find(id);
    }


    public void Remove(Zone entity)
    {
        _context.Set<Zone>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Zone> entities)
    {
        _context.Set<Zone>().RemoveRange(entities);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Zone entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
}
//private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
//public ZonnesRepository(ConnectedOfficeContext context) : base(context)
//{

//}
//ALL THE METHODS
//public Zone GetMostrecentCategory()
//{
//    return _context.Category.OrderByDescending(Category => Category.DateCreated).FirstOrDefault();
//}

// get all method 
//public List<Zone> Getall()
//{
//    return _context.Zone.ToList();
//}
//public async Task<IActionResult> Details(Guid? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var zone = await _context.Zone
//        .FirstOrDefaultAsync(m => m.ZoneId == id);
//    if (zone == null)
//    {
//        return NotFound();
//    }

//    return (IActionResult)zone.ZoneName.ToList();

//}

//private IActionResult NotFound()
//{
//    throw new NotImplementedException();
//}
