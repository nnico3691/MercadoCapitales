using System;

namespace GestorMercadoCapitales.Models
{
    public class RequetsParamEncuesta
    {
       public Guid? Volumen_ingre { get; set; }
       public Guid? Obj_renta { get; set; }
        public Guid? tol_riesgo { get; set; }
        public Guid? hor_inv { get; set; }
        public Guid? entend_merc { get; set; }
        public Guid? exp_inversion_1 { get; set; }
        public Guid? exp_inversion_2 { get; set; }
        public Guid? exp_inversion_3 { get; set; }
        public Guid? exp_inversion_4 { get; set; }
        public Guid? exp_inversion_5 { get; set; }
        public Guid? exp_inversion_6 { get; set; }

        public Guid? ClienteId { get; set; }
    }
}
