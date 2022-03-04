using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrdina_a_drak
{
    public interface IZasazitelne
    {
        double Zdravi { get; set; }

        double Obrana();

        void SnizZdravi(double hodnotaSnizeniZdravi);

        bool JeZivy();
    }
}
