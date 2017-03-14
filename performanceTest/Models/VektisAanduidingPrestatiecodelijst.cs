using System;
using System.Collections.Generic;
namespace performanceTest.Models {
    public sealed class VektisAanduidingPrestatiecodelijst : IVektisCodelijst<short> {
        public VektisAanduidingPrestatiecodelijst(short value, bool validCheck = true) {

        }

        public static string NaamCodelijst { get; }

        public short Code { get; set; }

        public DateTime? Expiratiedatum { get; }
        public DateTime Ingangsdatum { get; }
        public string Omschrijving { get; }

    }



    public interface IVektisCodelijst<T> {
        T Code { get; set; }
        DateTime? Expiratiedatum { get; }
        DateTime Ingangsdatum { get; }
        string Omschrijving { get; }
    }
}