using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJC2016.Model
{
    public class EquipistaInfo
    {

        public int Id;
        public int EquipeId;
        public int PessoaId;
        public PessoaInfo PessoaInfo;
        public String UpdateDate;
        private String CreateDate;
        public String Coordenador;

        public int getId()
        {
            return Id;
        }

        public void setId(int id)
        {
            Id = id;
        }

        public int getEquipeId()
        {
            return EquipeId;
        }

        public void setEquipeId(int equipeId)
        {
            EquipeId = equipeId;
        }

        public PessoaInfo getPessoaInfo()
        {
            return PessoaInfo;
        }

        public void setPessoaInfo(PessoaInfo pessoaInfo)
        {
            PessoaInfo = pessoaInfo;
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

        public int getPessoaId()
        {
            return PessoaId;
        }

        public void setPessoaId(int pessoaId)
        {
            PessoaId = pessoaId;
        }

        public String getCoordenador()
        {
            return Coordenador;
        }

        public void setCoordenador(String coordenador)
        {
            Coordenador = coordenador;
        }
    }
}
