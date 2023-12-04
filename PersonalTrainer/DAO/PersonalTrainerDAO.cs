using AcompanhamentoFisico.DTO;
using System.Data.SqlClient;
using System.Data;
using AcompanhamentoFisico.Model;
using AutoMapper;

namespace AcompanhamentoFisico.DAO
{
    public class PersonalTrainerDAO
    {
        String conexao = @"Server=DESKTOP-BJNTUCI\MSSQLSERVER01;Database=Cliente;Trusted_Connection=True";
        #region Personal Trainer

        public PersonalTrainerDTO retornaPersonalTrainer(String CREF)
        {
                PersonalTrainerDTO personalTrainerDTO = new PersonalTrainerDTO();
                PersonalTrainer personalTrainer = new PersonalTrainer();

            string sql = "select id_personaltrainer,nome,CREF from Personal_trainer  where CREF=" + CREF;

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    personalTrainer.idPersonal = Convert.ToInt32(reader[0]);
                    personalTrainer.nome = reader[1].ToString();
                    personalTrainer.CREF = reader[2].ToString();

                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<PersonalTrainer, PersonalTrainerDTO>();
                    });
                    var mapper = configuration.CreateMapper();
                    personalTrainerDTO = mapper.Map<PersonalTrainerDTO>(personalTrainer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }

            return personalTrainerDTO;
        }

        public int InserePersonalTrainer(PersonalTrainerDTO personalTrainerDTO)
        {
           
            string sql = "INSERT INTO dbo.Personal_Trainer (nome,CREF) VALUES (" + "'" + personalTrainerDTO.nome + "'" + "," + "'" + personalTrainerDTO.CREF + "'" + ")";

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();
            int retorno = cmd.ExecuteNonQuery();

            return retorno;
        }



        public int alteraPersonalTrainer(PersonalTrainerDTO personalTrainerDTO)
        {


            string sql = "UPDATE dbo.Personal_trainer SET  nome=" + "'" + personalTrainerDTO.nome + "'" + "   where CREF=" + "'" + personalTrainerDTO.CREF + "'";
            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            int retorno = cmd.ExecuteNonQuery();

            return retorno;
        }


        public int deletaPersonalTrainer(String CREF)
        {
            String retorno = "";
            string sql = "delete from dbo.Personal_Trainer where CREF = " + CREF;

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            int i = cmd.ExecuteNonQuery();
            return i;

        }
        #endregion
    }
}
