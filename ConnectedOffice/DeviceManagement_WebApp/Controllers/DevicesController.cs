﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repositories;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        

        DeviceRepository _deviceRepository = new DeviceRepository();
        
        //1 
        // GET: Devices 
        public async Task<IActionResult> Index()
        {
            var result = _deviceRepository.GetAll();
            return View(result);
        }

        //2 
        // GET: Devices/Details/5 
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            } 
            var result = _deviceRepository.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }


        //3 
        // GET: Devices/Create 
        public IActionResult Create()
        {

            return View();
        }


        //4 
        // POST: Devices/Create 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for  
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _deviceRepository.Add(device);
            _deviceRepository.Save();
            return RedirectToAction(nameof(Index));


        }

        // GET: Devices/Edit/5 
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Edit/5 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for  
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598. 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }
            try
            {
                _deviceRepository.Update(device);
                _deviceRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != (device.DeviceId))
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

        // GET: Devices/Delete/5 
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }
    }
}

