using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BibliotekaAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BibliotekaController : ControllerBase
    {

        public BibliotekaContext Context { get; set; }

        public BibliotekaController(BibliotekaContext b){
            Context = b;
        }

        [HttpPost]
        [Route("UbaciBiblioteku")]
        public async Task<IActionResult> UbaciBiblioteku([FromBody] Biblioteka b)
        {
            Context.Biblioteke.Add(b);
            await Context.SaveChangesAsync();
            return Ok();
        } 

        [HttpPost]
        [Route("UbaciPolicu/{id}")]
        public async Task<IActionResult> UbaciPolicu([FromBody] Polica p, int id)
        {
            p.Biblioteka = await Context.Biblioteke.FindAsync(id);
            Context.Police.Add(p);
            p.Biblioteka.Police.Add(p);
            await Context.SaveChangesAsync();
            return Ok();
        } 

        [HttpPost]
        [Route("UbaciKnjigu/{id}")]
        public async Task<IActionResult> UbaciKnjigu([FromBody] Knjiga k, int id)
        {
            k.Polica = await Context.Police.FindAsync(id);
            Context.Knjige.Add(k);

            k.Polica.Knjige.Add(k);

            await Context.SaveChangesAsync();
            return  StatusCode(k.ID);
        } 


        [HttpGet]
        [Route("PreuzmiBiblioteke")]
        public async Task<List<Biblioteka>> PreuzmiBiblioteke()
        {
            return await Context.Biblioteke.Include(p=>p.Police).ToListAsync();
        }


        [HttpGet]
        [Route("PreuzmiKnjige/{id}")]
        public async Task<List<Knjiga>> PreuzmiKnjige(int id)
        {
            return await Context.Knjige.Where(e => e.Polica.ID == id).ToListAsync();
        }


        [HttpPut]
        [Route("PromeniIme/{id}/{ime}")]
        public async Task<IActionResult> PromeniIme(int id,string ime)
        {
            Biblioteka b =await Context.Biblioteke.FindAsync(id);
            if(b == null)
            return BadRequest(404);
            b.Ime = ime;
            Context.Biblioteke.Update(b);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("IzbrisiKnjigu/{id}")]
        public async Task<IActionResult> IzbrisiKnjigu(int id)
        {
            Knjiga k =await Context.Knjige.FindAsync(id);
            if(k == null)
            return BadRequest(404);
            
            Context.Knjige.Remove(k);

            await Context.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete]
        [Route("IzbrisiPolicu/{id}")]
        public async Task<IActionResult> IzbrisiPolicu(int id)
        {
            Polica p =await Context.Police.FindAsync(id);
            if(p == null)
            return BadRequest(404);
            
            Context.Police.Remove(p);

            await Context.SaveChangesAsync();

            return Ok();

        }





    }

}