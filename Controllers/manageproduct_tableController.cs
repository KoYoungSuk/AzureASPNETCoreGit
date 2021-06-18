using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AzureWebApplication.Data;
using AzureWebApplication.Models;
using ManageContext = AzureWebApplication.Data.ManageContext;
using Microsoft.Extensions.Logging;

namespace AzureWebApplication.Controllers
{
    public class manageproduct_tableController : Controller
    {
        private readonly ManageContext context;

        public manageproduct_tableController(ManageContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Manage()
        {
            return View(await context.manageproduct_table.ToListAsync());
        }
        // GET: manageproduct_table/Details/5      
 
        public async Task<IActionResult> Details(string id)
        {
             if (id == null)
            {
                return NotFound();
            }
            var manageproduct_table = await context.manageproduct_table.FirstOrDefaultAsync(m => m.product_no.Equals(id));
            if (manageproduct_table == null)
            {
                return NotFound();
            }
            return View(manageproduct_table);
        }

        // GET: manageproduct_table/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("product_no,product_name,product_type,manufacture_date,expired_date,product_amount, buy_date, price")] manageproduct_table manageproduct_table)
        {
            if (ModelState.IsValid)
            {
                context.Add(manageproduct_table);
                await context.SaveChangesAsync();
                return Redirect("/manageproduct_table/Manage");
            }
            return View(manageproduct_table);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageproduct_table = await context.manageproduct_table.FindAsync(id);
            if (manageproduct_table == null)
            {
                return NotFound();
            }

            return View(manageproduct_table);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("product_no,product_name,product_type,manufacture_date,expired_date,product_amount,buy_date,price")] manageproduct_table manageproduct_table)
        {
            if (id != manageproduct_table.product_no)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(manageproduct_table);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!manageproduct_tableExists(manageproduct_table.product_no))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/manageproduct_table/Manage");
            }
            return View(manageproduct_table);           
        }

 
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageproduct_table = await context.manageproduct_table
                .FirstOrDefaultAsync(m => m.product_no == id);
            if (manageproduct_table == null)
            {
                return NotFound();
            }

            return View(manageproduct_table);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var manageproduct_table = await context.manageproduct_table.FindAsync(id);
            context.manageproduct_table.Remove(manageproduct_table);
            await context.SaveChangesAsync();
            return Redirect("/manageproduct_table/Manage");
        }

        private bool manageproduct_tableExists(string id)
        {
            return context.manageproduct_table.Any(e => e.product_no == id);
        }
    }
}
