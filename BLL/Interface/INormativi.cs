using System;
using BLL.Models;

namespace BLL.Interface
{
    public interface INormativi
    {
        //Normativi CreateNormativi(Normativi normativi);
        ICollection<Normativi> GetAllNormativi();
        Normativi GetNormativiId(int id);
        List<Normativi> GetNormativByArticleId(int articleId);
        Normativi GetNormativiByArticleId(int artikalId);

    }

}

