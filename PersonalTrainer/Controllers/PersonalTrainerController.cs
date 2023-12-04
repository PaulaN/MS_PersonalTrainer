using AcompanhamentoFisico.BLL;
using AcompanhamentoFisico.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcompanhamentoFisico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalTrainerController : ControllerBase
    {
        PersonalTrainerBLL bll = new PersonalTrainerBLL();

        [HttpGet("{CREF}")]
        public PersonalTrainerDTO BuscaPorCREF(String CREF)
        {


            PersonalTrainerDTO personalTrainerDTO = bll.retornaPersonalTrainer(CREF);


            return personalTrainerDTO;
        }

        [HttpPost]
        public String Post(PersonalTrainerDTO personalTrainerDTO)
        {
            String retorno = bll.inserePersonalTrainer(personalTrainerDTO);

            return retorno;
        }

        [HttpPut]
        public String Put(PersonalTrainerDTO personalTrainerDTO)
        {
            String retorno = bll.alteraPersonalTrainer(personalTrainerDTO);

            return retorno;
        }



        [HttpDelete("{CREF}")]
        public String Delete(String CREF)
        {
            String retorno = bll.deletaPersonalTrainer(CREF);

            return retorno;
        }
    }
}
