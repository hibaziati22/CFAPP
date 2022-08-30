using CfAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CFController : ControllerBase
    {
        // A declarer le context Et le reinitialiser dans le constrcuteur !!
       
        private readonly DataContext context; // valeur de context a ce niveau est undifined

        public CFController(DataContext contexte)
        {
            this.context = contexte; // Intialiser le context controller par le context Service.
        }

        [HttpGet]
        public async Task<ActionResult<List<CF>>> Get()
        {
            // a recuperer de la bdd
            return Ok(await this.context.CFs.ToListAsync()); // <=> select * from Cfc
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CF>> Get(int id)
        {
            var ConservF = await this.context.CFs.FindAsync(id); // select * from Cfs Where Id = id;
            
            if (ConservF == null)
                return BadRequest(" CF not found");
            
            
            return Ok(ConservF);
        }




        [HttpPost]
        public async Task<ActionResult<CF>> AddCF(CF ConservF)
        {
           this.context.CFs.Add(ConservF); //  insert 

            await this.context.SaveChangesAsync();
            return Ok(ConservF);
        }



        [HttpPut]
        public async Task<ActionResult<List<CF>>> UpdateCF(CF ConservF)
        {
            var dbConservF = await this.context.CFs.FindAsync(ConservF.Id);
            if (dbConservF == null)
                return BadRequest(" CF not found");

           // dbConservF.Nom = ConservF.Nom;
            //dbConservF.Code = ConservF.Code;


            //context.CFs.Update(ConservF);
            await this.context.SaveChangesAsync();

            return Ok(await this.context.CFs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CF>>> Delete(int id)
        {
            var dbConservF = await this.context.CFs.FindAsync(id);
            if (dbConservF == null)
                return BadRequest(" CF not found");

            this.context.CFs.Remove(dbConservF);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.CFs.ToListAsync());
        }

    }
}
