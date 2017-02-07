using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJC2016.Model
{
    public class EquipeInfo
    {

        public int Id;
        public String Nome;
        public String Frase;
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

        public String getNome()
        {
            return Nome;
        }

        public void setNome(String nome)
        {
            Nome = nome;
        }

        public String getFrase()
        {
            return Frase;
        }

        public void setFrase(String frase)
        {
            Frase = frase;
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
