using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJC2016.Model
{
    public class EncontristaInfo
    {

        public int Id;
        public int PessoaId;
        public PessoaInfo PessoaInfo;
        public String UpdateDate;
        public String CreateDate;
        public System.Drawing.Image Foto;

        public int getId()
        {
            return Id;
        }

        public void setId(int id)
        {
            Id = id;
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

        public System.Drawing.Image getFoto()
        {
            return Foto;
        }

        public void setFoto(System.Drawing.Image foto)
        {
            Foto = foto;
        }
    }
}
