using AcompanhamentoFisico.DAO;
using AcompanhamentoFisico.DTO;

namespace AcompanhamentoFisico.BLL
{
    public class PersonalTrainerBLL
    {

        #region Personal trainer

        PersonalTrainerDAO dao = new PersonalTrainerDAO();

        private int  retornoPersonal = 0;
        public PersonalTrainerDTO retornaPersonalTrainer(String CREF)
        {

            PersonalTrainerDTO personalTrainerDTO = dao.retornaPersonalTrainer(CREF);


            return personalTrainerDTO;
        }
        public String inserePersonalTrainer(PersonalTrainerDTO personalTrainerDTO)
        {
            retornoPersonal = 0;
            retornoPersonal = dao.InserePersonalTrainer(personalTrainerDTO);

            return retornoPersonal == 1 ? "Cadastro realizado com sucesso" : "Não foi possível cadastrar personal trainer";
        }

        public String alteraPersonalTrainer(PersonalTrainerDTO personalTrainerDTO)
        {
            retornoPersonal = 0;

            retornoPersonal = dao.alteraPersonalTrainer(personalTrainerDTO);

            return retornoPersonal == 1 ? "Alteração realizada com sucesso" : "Não foi possível alterar personal trainer";
        }

        public String deletaPersonalTrainer(String CREF)
        {
            retornoPersonal = 0;


            if (CREF != null)
            {
                retornoPersonal = dao.deletaPersonalTrainer(CREF);
            }

            return retornoPersonal == 1 ? "Dados deletados com sucesso" : "Não foi possível deletar personal trainer";
        }


        #endregion
    }
}
