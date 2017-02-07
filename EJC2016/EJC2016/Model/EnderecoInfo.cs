using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJC2016.Model
{
    public class EnderecoInfo
    {

        public int Id;
        public String Endereco;
        public int Numero;
        public String Bairro;
        public String Tel1;
        public String Tel2;
        public String Cel1;
        public String Cel2;
        private String UpdateDate;
        private String CreateDate;

        public int getId()
        {
            return Id;
        }

        public void setId(int id)
        {
            Id = id;
        }

        public String getEndereco()
        {
            return Endereco;
        }

        public void setEndereco(String endereco)
        {
            Endereco = endereco;
        }

        public int getNumero()
        {
            return Numero;
        }

        public void setNumero(int numero)
        {
            Numero = numero;
        }

        public String getBairro()
        {
            return Bairro;
        }

        public void setBairro(String bairro)
        {
            Bairro = bairro;
        }

        public String getTel1()
        {
            return Tel1;
        }

        public void setTel1(String tel1)
        {
            Tel1 = tel1;
        }

        public String getTel2()
        {
            return Tel2;
        }

        public void setTel2(String tel2)
        {
            Tel2 = tel2;
        }

        public String getCel1()
        {
            return Cel1;
        }

        public void setCel1(String cel1)
        {
            Cel1 = cel1;
        }

        public String getCel2()
        {
            return Cel2;
        }

        public void setCel2(String cel2)
        {
            Cel2 = cel2;
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
    }
}