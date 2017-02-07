using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJC2016.Model
{
    public class PessoaInfo
    {

        public int Id;
        public String Nome;
        public String Email;
        public int Idade;
        public int EnderecoId;
        private String UpdateDate;
        private String CreateDate;
        public EnderecoInfo EnderecoInfo;

        public int getId()
        {
            return Id;
        }

        public void setId(int id)
        {
            Id = id;
        }

        public String getNome()
        {
            return Nome;
        }

        public void setNome(String nome)
        {
            Nome = nome;
        }

        public String getEmail()
        {
            return Email;
        }

        public void setEmail(String email)
        {
            Email = email;
        }

        public int getIdade()
        {
            return Idade;
        }

        public void setIdade(int idade)
        {
            Idade = idade;
        }

        public int getEnderecoId()
        {
            return EnderecoId;
        }

        public void setEnderecoId(int enderecoId)
        {
            EnderecoId = enderecoId;
        }

        public String getUpdateDate()
        {
            return UpdateDate;
        }

        public void setUpdateDate(String updateDate)
        {
            UpdateDate = updateDate;
        }

        public String getCreateDate()
        {
            return CreateDate;
        }

        public void setCreateDate(String createDate)
        {
            CreateDate = createDate;
        }

        public EnderecoInfo getEnderecoInfo()
        {
            return EnderecoInfo;
        }

        public void setEnderecoInfo(EnderecoInfo enderecoInfo)
        {
            EnderecoInfo = enderecoInfo;
        }
    }
}